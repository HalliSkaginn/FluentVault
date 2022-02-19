﻿using System.Xml.Linq;

using FluentAssertions;

using FluentVault.Domain.Category;
using FluentVault.UnitTests.Fixtures;

using Xunit;

namespace FluentVault.UnitTests.Systems;

public class VaultCategoryParsingExtensionsTests
{
    [Fact]
    public void ParseVaultLifecycle_ShouldReturnValidResult_WhenParsingValidString()
    {
        // Arrange
        var (body, expectation) = VaultResponseFixtures.GetVaultCategoryFixtures(5);
        var document = XDocument.Parse(body);

        // Act
        var result = document.ParseCategories();

        // Assert
        result.Should().BeEquivalentTo(expectation);
    }
}
