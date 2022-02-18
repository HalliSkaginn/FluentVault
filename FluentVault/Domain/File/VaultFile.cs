﻿namespace FluentVault;

public record VaultFile(
    long Id,
    string Filename,
    long MasterId,
    string VersionName,
    long VersionNumber,
    long MaximumCheckInVersionNumber,
    string Comment,
    DateTime ChecedkInDate,
    DateTime CreatedDate,
    DateTime ModifiedDate,
    long CreateUserId,
    string CreateUserName,
    long CheckSum,
    long FileSize,
    bool IsCheckedOut,
    long FolderId,
    string CheckedOutPath,
    string CheckedOutMachine,
    long CheckedOutUserId,
    string FileClass,
    VaultFileStatus FileStatus,
    bool IsLocked,
    bool IsHidden,
    bool IsCloaked,
    bool IsOnSite,
    bool IsControlledByChangeOrder,
    string DesignVisualAttachmentStatus,
    VaultFileRevision Revision,
    VaultFileLifecycle Lifecycle,
    VaultFileCategory Category);
