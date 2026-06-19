using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Pinwheel.Jupiter
{
	[CreateAssetMenu(menuName = "Jupiter/Day Night Cycle Profile")]
	public class JDayNightCycleProfile : ScriptableObject
	{
		private static Dictionary<string, int> propertyRemap;

		private static Dictionary<string, PropertyInfo> scriptPropertyRemap;

		private static Dictionary<string, Action<JSkyProfile, float>> scriptFloatSetterRemap;

		private static Dictionary<string, Action<JSkyProfile, Color>> scriptColorSetterRemap;

		[SerializeField]
		private List<JAnimatedProperty> animatedProperties;

		private static Dictionary<string, int> PropertyRemap
		{
			get
			{
				if (propertyRemap == null)
				{
					propertyRemap = new Dictionary<string, int>();
				}
				return propertyRemap;
			}
			set
			{
				propertyRemap = value;
			}
		}

		private static Dictionary<string, PropertyInfo> ScriptPropertyRemap
		{
			get
			{
				if (scriptPropertyRemap == null)
				{
					scriptPropertyRemap = new Dictionary<string, PropertyInfo>();
				}
				return scriptPropertyRemap;
			}
			set
			{
				scriptPropertyRemap = value;
			}
		}

		private static Dictionary<string, Action<JSkyProfile, float>> ScriptFloatSetterRemap
		{
			get
			{
				if (scriptFloatSetterRemap == null)
				{
					scriptFloatSetterRemap = new Dictionary<string, Action<JSkyProfile, float>>();
				}
				return scriptFloatSetterRemap;
			}
		}

		private static Dictionary<string, Action<JSkyProfile, Color>> ScriptColorSetterRemap
		{
			get
			{
				if (scriptColorSetterRemap == null)
				{
					scriptColorSetterRemap = new Dictionary<string, Action<JSkyProfile, Color>>();
				}
				return scriptColorSetterRemap;
			}
		}

		public List<JAnimatedProperty> AnimatedProperties
		{
			get
			{
				if (animatedProperties == null)
				{
					animatedProperties = new List<JAnimatedProperty>();
				}
				return animatedProperties;
			}
			set
			{
				animatedProperties = value;
			}
		}

		static JDayNightCycleProfile()
		{
			InitPropertyRemap();
		}

		private static void InitPropertyRemap()
		{
			PropertyRemap.Clear();
			ScriptPropertyRemap.Clear();
			ScriptFloatSetterRemap.Clear();
			ScriptColorSetterRemap.Clear();
			PropertyInfo[] properties = typeof(JSkyProfile).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (!(propertyInfo.GetCustomAttribute(typeof(JAnimatableAttribute), inherit: false) is JAnimatableAttribute jAnimatableAttribute))
				{
					continue;
				}
				string text = propertyInfo.Name;
				int value = Shader.PropertyToID("_" + text);
				PropertyRemap.Add(text, value);
				ScriptPropertyRemap.Add(text, propertyInfo);
				if (jAnimatableAttribute.Target != JAnimateTarget.SkyProfile)
				{
					continue;
				}
				MethodInfo setMethod = propertyInfo.GetSetMethod();
				if (setMethod != null)
				{
					if (propertyInfo.PropertyType == typeof(float))
					{
						ScriptFloatSetterRemap.Add(text, (Action<JSkyProfile, float>)Delegate.CreateDelegate(typeof(Action<JSkyProfile, float>), null, setMethod));
					}
					else if (propertyInfo.PropertyType == typeof(Color))
					{
						ScriptColorSetterRemap.Add(text, (Action<JSkyProfile, Color>)Delegate.CreateDelegate(typeof(Action<JSkyProfile, Color>), null, setMethod));
					}
				}
			}
		}

		public void AddProperty(JAnimatedProperty p, bool setDefaultValue = true)
		{
			if (setDefaultValue)
			{
				JDayNightCycleProfile defaultDayNightCycleProfile = JJupiterSettings.Instance.DefaultDayNightCycleProfile;
				if (defaultDayNightCycleProfile != null)
				{
					JAnimatedProperty jAnimatedProperty = defaultDayNightCycleProfile.AnimatedProperties.Find((JAnimatedProperty jAnimatedProperty2) => jAnimatedProperty2.Name != null && jAnimatedProperty2.Name.Equals(p.Name));
					if (jAnimatedProperty != null)
					{
						p.Curve = jAnimatedProperty.Curve;
						p.Gradient = jAnimatedProperty.Gradient;
					}
				}
			}
			AnimatedProperties.Add(p);
		}

		public void Animate(JSky sky, float t)
		{
			JSkyProfile profile = sky.Profile;
			if (profile == null)
			{
				return;
			}
			CheckDefaultProfileAndThrow(profile);
			Material material = profile.Material;
			int count = AnimatedProperties.Count;
			for (int i = 0; i < count; i++)
			{
				JAnimatedProperty jAnimatedProperty = AnimatedProperties[i];
				if (jAnimatedProperty.Target == JAnimateTarget.Material)
				{
					if (PropertyRemap.TryGetValue(jAnimatedProperty.Name, out var value))
					{
						if (jAnimatedProperty.CurveOrGradient == JCurveOrGradient.Curve)
						{
							material.SetFloat(value, jAnimatedProperty.EvaluateFloat(t));
						}
						else
						{
							material.SetColor(value, jAnimatedProperty.EvaluateColor(t));
						}
					}
				}
				else
				{
					if (jAnimatedProperty.Target != JAnimateTarget.SkyProfile)
					{
						continue;
					}
					Action<JSkyProfile, Color> value4;
					PropertyInfo value5;
					if (jAnimatedProperty.CurveOrGradient == JCurveOrGradient.Curve)
					{
						PropertyInfo value3;
						if (ScriptFloatSetterRemap.TryGetValue(jAnimatedProperty.Name, out var value2))
						{
							value2(profile, jAnimatedProperty.EvaluateFloat(t));
						}
						else if (ScriptPropertyRemap.TryGetValue(jAnimatedProperty.Name, out value3))
						{
							value3.SetValue(profile, jAnimatedProperty.EvaluateFloat(t));
						}
					}
					else if (ScriptColorSetterRemap.TryGetValue(jAnimatedProperty.Name, out value4))
					{
						value4(profile, jAnimatedProperty.EvaluateColor(t));
					}
					else if (ScriptPropertyRemap.TryGetValue(jAnimatedProperty.Name, out value5))
					{
						value5.SetValue(profile, jAnimatedProperty.EvaluateColor(t));
					}
				}
			}
		}

		private void CheckDefaultProfileAndThrow(JSkyProfile p)
		{
			if (p == null || (!(p == JJupiterSettings.Instance.DefaultProfileSunnyDay) && !(p == JJupiterSettings.Instance.DefaultProfileStarryNight)))
			{
				return;
			}
			throw new ArgumentException("Animating default sky profile is prohibited. You must create a new profile for your sky to animate it.");
		}

		public bool ContainProperty(string propertyName)
		{
			for (int i = 0; i < AnimatedProperties.Count; i++)
			{
				if (AnimatedProperties[i].Name != null && AnimatedProperties[i].Name.Equals(propertyName))
				{
					return true;
				}
			}
			return false;
		}
	}
}
