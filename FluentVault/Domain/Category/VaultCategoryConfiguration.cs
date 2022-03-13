﻿using System.Xml.Linq;

using FluentVault.Extensions;

namespace FluentVault;

public record VaultCategoryConfiguration(
    VaultCategoryId Id,
    string Name,
    string SystemName,
    long Color,
    string Description,
    IEnumerable<EntityClass> EntityClasses)
{
    internal static IEnumerable<VaultCategoryConfiguration> ParseAll(XDocument document)
        => document.ParseAllElements("Cat", ParseCategory);

    private static VaultCategoryConfiguration ParseCategory(XElement element)
        => new(element.ParseAttributeValue("Id", VaultCategoryId.Parse),
            element.GetElementValue("Name"),
            element.GetElementValue("SysName"),
            element.ParseElementValue("Color", long.Parse),
            element.GetElementValue("Descr"),
            element.ParseAllElementValues("EntClassId", x => EntityClass.FromName(x)));
}
