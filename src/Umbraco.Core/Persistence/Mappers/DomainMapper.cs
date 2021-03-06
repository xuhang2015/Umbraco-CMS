﻿using System.Collections.Concurrent;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence.Dtos;

namespace Umbraco.Core.Persistence.Mappers
{
    [MapperFor(typeof(IDomain))]
    [MapperFor(typeof(UmbracoDomain))]
    public sealed class DomainMapper : BaseMapper
    {
        private static readonly ConcurrentDictionary<string, DtoMapModel> PropertyInfoCacheInstance = new ConcurrentDictionary<string, DtoMapModel>();

        internal override ConcurrentDictionary<string, DtoMapModel> PropertyInfoCache => PropertyInfoCacheInstance;

        protected override void BuildMap()
        {
            CacheMap<UmbracoDomain, DomainDto>(src => src.Id, dto => dto.Id);
            CacheMap<UmbracoDomain, DomainDto>(src => src.RootContentId, dto => dto.RootStructureId);
            CacheMap<UmbracoDomain, DomainDto>(src => src.LanguageId, dto => dto.DefaultLanguage);
            CacheMap<UmbracoDomain, DomainDto>(src => src.DomainName, dto => dto.DomainName);
        }
    }
}
