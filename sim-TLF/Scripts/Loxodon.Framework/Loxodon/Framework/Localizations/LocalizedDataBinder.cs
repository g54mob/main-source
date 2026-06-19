using System;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Observables;
using Loxodon.Log;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Loxodon.Framework.Localizations
{
	[AddComponentMenu("Loxodon/Localization/LocalizedDataBinder")]
	[DisallowMultipleComponent]
	[AllowedMembers(typeof(RectTransform), new string[] { "offsetMax", "offsetMin", "pivot", "sizeDelta", "anchoredPosition", "anchorMax", "anchoredPosition3D", "rect", "anchorMin" })]
	[AllowedMembers(typeof(Image), new string[] { "sprite", "material", "color" })]
	[AllowedMembers(typeof(RawImage), new string[] { "texture", "material", "color" })]
	[AllowedMembers(typeof(SpriteRenderer), new string[] { "sprite", "color", "drawMode" })]
	[AllowedMembers(typeof(Text), new string[] { "text", "font", "fontStyle", "fontSize", "color" })]
	[AllowedMembers(typeof(TextMesh), new string[] { "text", "font", "fontStyle", "fontSize", "color" })]
	[AllowedMembers(typeof(AudioSource), new string[] { "clip" })]
	[AllowedMembers(typeof(VideoPlayer), new string[] { "clip", "url" })]
	public class LocalizedDataBinder : MonoBehaviour
	{
		private static readonly ILog log = LogManager.GetLogger("LocalizedComponent");

		[SerializeField]
		protected LocalizedBindingDescriptionSet data = new LocalizedBindingDescriptionSet();

		protected virtual void Start()
		{
			Localization current = Localization.Current;
			BindingSet bindingSet = this.CreateSimpleBindingSet();
			foreach (LocalizedBindingDescription description in data.descriptions)
			{
				string typeName = description.TypeName;
				Component componentByName = GetComponentByName(typeName);
				if (componentByName == null)
				{
					throw new MissingComponentException($"Not found the \"{typeName}\" component.");
				}
				string propertyName = description.PropertyName;
				string key = description.Key;
				BindingMode mode = description.Mode;
				if (string.IsNullOrEmpty(key))
				{
					if (log.IsWarnEnabled)
					{
						log.WarnFormat("The key is null or empty.Please check the binding \"{0}\" in the GameObject \"{1}\"", description.ToString(), base.name);
					}
				}
				else
				{
					IObservableProperty value = current.GetValue(key);
					BindingBuilder bindingBuilder = bindingSet.Bind(componentByName).For(propertyName).ToValue(value);
					if (mode == BindingMode.OneTime)
					{
						bindingBuilder.OneTime();
					}
					else
					{
						bindingBuilder.OneWay();
					}
				}
			}
			bindingSet.Build();
		}

		protected virtual Component GetComponentByName(string typeName)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				return null;
			}
			object[] customAttributes = GetType().GetCustomAttributes(typeof(AllowedMembersAttribute), inherit: true);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				Type type = ((AllowedMembersAttribute)customAttributes[i]).Type;
				if (typeName.Equals(type.FullName))
				{
					Component component = GetComponent(type);
					if (!(component != null))
					{
						break;
					}
					return component;
				}
			}
			return GetComponent(typeName);
		}
	}
}
