﻿using FoxIDs.Models;
using FoxIDs.ResourceTranslateTool.Models;
using ITfoxtec.Identity;

namespace FoxIDs.ResourceTranslateTool.Logic
{
    public class ResourceLogic
    {
        private readonly TranslateSettings translateSettings;

        public ResourceLogic(TranslateSettings translateSettings)
        {
            this.translateSettings = translateSettings;
        }

        public ResourceEnvelope ResourceEnvelope { get; set; }

        public async Task LoadResourcesAsync()
        {
            var json = await File.ReadAllTextAsync(translateSettings.EmbeddedResourceJsonPath);
            await json.ValidateObjectAsync();
            ResourceEnvelope = json.ToObject<ResourceEnvelope>();
        }

        public async Task SaveResourcesAsync()
        {
            var json = ResourceEnvelope.ToJsonIndented();
            await json.ValidateObjectAsync();
            await File.WriteAllTextAsync(translateSettings.EmbeddedResourceJsonPath, json);
        }
    }
}
