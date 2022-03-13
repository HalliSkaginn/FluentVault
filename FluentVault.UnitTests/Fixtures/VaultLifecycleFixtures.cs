﻿using System.Collections.Generic;

using AutoFixture;

namespace FluentVault.UnitTests.Fixtures;

internal static partial class VaultResponseFixtures
{
    public static (string Body, IEnumerable<VaultLifeCycleDefinition> Files) GetVaultLifecycleFixtures(int count)
    {
        Fixture fixture = new();
        fixture.Register(() => VaultRestrictPurgeOption.All);
        fixture.Register(() => VaultItemToFileSecurityMode.ApplyACL);
        fixture.Register(() => VaultFolderFileSecurityMode.RemoveACL);
        fixture.Register(() => VaultBumpRevisionState.BumpProperty);
        fixture.Register(() => VaultSynchronizePropertiesState.SyncPropAndUpdateView);
        fixture.Register(() => VaultEnforceChildState.EnforceChildItemsHaveBeenReleased);
        fixture.Register(() => VaultEnforceContentState.EnforceLinkToItems);
        fixture.Register(() => VaultFileLinkTypeState.StandardComp);
        fixture.Register(() => VaultFileLinkTypeState.DesignDocs);

        return CreateBody<VaultLifeCycleDefinition>(fixture, count, "GetAllLifeCycleDefinitions", "http://AutodeskDM/Services/LifeCycle/1/7/2020/", CreateLifecycleBody);
    }

    private static string CreateLifecycleBody(VaultLifeCycleDefinition lifecycle) => $@"<LfCycDef 
                Id=""{lifecycle.Id}""
				Name=""{lifecycle.Name}""
				SysName=""{lifecycle.SystemName}""
				DispName=""{lifecycle.DisplayName}""
				Descr=""{lifecycle.Description}""
				SysAclBeh=""{lifecycle.SecurityDefinition}"">
				<StateArray>
                    {CreateEntityBody(lifecycle.States, CreateStateBody)}
                </StateArray>
                <TransArray>
                    {CreateEntityBody(lifecycle.Transitions, CreateTransitionBody)}
                </TransArray>
            </LfCycDef>";

    private static string CreateStateBody(VaultLifeCycleState state) => $@"<State 
						ID=""{state.Id}""
						Name=""{state.Name}""
						DispName=""{state.DisplayName}""
						Descr=""{state.Description}""
						IsDflt=""{state.IsDefault}""
						LfCycDefId=""{state.LifecycleId}""
						StateBasedSec=""{state.HasStateBasedSecurity}""
						ReleasedState=""{state.IsReleasedState}""
						ObsoleteState=""{state.IsObsoleteState}""
						DispOrder=""{state.DisplayOrder}""
						RestrictPurgeOption=""{state.RestrictPurgeOption}""
						ItemFileSecMode=""{state.ItemFileSecurityMode}""
						FolderFileSecMode=""{state.FolderFileSecurityMode}"">
                        <CommArray>
                            {CreateElementArray(state.Comments, "Comm")}
                        </CommArray>
                    </State>";

    private static string CreateTransitionBody(VaultLifeCycleTransition transition) => $@"<Trans 
                        Id=""{transition.Id}""
						FromId=""{transition.FromId}""
						ToId=""{transition.ToId}""
						Bump=""{transition.BumpRevision}""
						SyncPropOption=""{transition.SynchronizeProperties}""
						CldState=""{transition.EnforceChildState}""
						CtntState=""{transition.EnforceContentState}""
						ItemFileLnkUptodate=""{transition.ItemFileLnkUptodate}""
						ItemFileLnkState=""{transition.ItemFileLnkState}""
						CldObsState=""{transition.VerifyThatChildIsNotObsolete}""
						TransBasedSec=""{transition.TransitionBasedSecurity}""
						UpdateItems=""{transition.UpdateItems}""/>";
}
