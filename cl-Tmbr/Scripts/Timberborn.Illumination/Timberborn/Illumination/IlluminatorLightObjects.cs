using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.EntitySystem;
using Timberborn.TemplateAttachmentSystem;
using UnityEngine;

namespace Timberborn.Illumination
{
	internal class IlluminatorLightObjects : BaseComponent, IInitializableEntity
	{
		private readonly List<Light> _lightObjects = new List<Light>();

		public void InitializeEntity()
		{
			TemplateAttachments component = GetComponent<TemplateAttachments>();
			ImmutableArray<string>.Enumerator enumerator = GetComponent<IlluminatorLightObjectsSpec>().AttachmentIds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				TemplateAttachment orCreateAttachment = component.GetOrCreateAttachment(current);
				_lightObjects.AddRange(orCreateAttachment.GameObject.GetComponentsInChildren<Light>());
			}
			SetActive(isActive: false);
			if (_lightObjects.Count == 0)
			{
				throw new NotSupportedException("No lights found in IlluminatorLightObjects on " + base.Name + ".");
			}
		}

		public void SetActive(bool isActive)
		{
			foreach (Light lightObject in _lightObjects)
			{
				lightObject.enabled = isActive;
			}
		}
	}
}
