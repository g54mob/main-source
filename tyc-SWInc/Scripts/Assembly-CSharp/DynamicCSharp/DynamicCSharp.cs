using System;
using System.Collections.Generic;
using System.Reflection;
using DynamicCSharp.Security;
using UnityEngine;

namespace DynamicCSharp
{
	public sealed class DynamicCSharp : ScriptableObject
	{
		private const string editorSettingsDirectory = "/Resources";

		private const string settingsLocation = "DynamicCSharp_Settings";

		private const BindingFlags defaultFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;

		private static DynamicCSharp instance = null;

		public bool caseSensitiveNames;

		public bool discoverNonPublicTypes = true;

		public bool discoverNonPublicMembers = true;

		public bool securityCheckCode = true;

		public readonly bool debugMode;

		[HideInInspector]
		public string compilerWorkingDirectory = "";

		public string[] assemblyReferences = new string[1] { "Assembly-CSharp.dll" };

		public static readonly string[] unityAssemblyReferences = new string[6] { "UnityEngine.AudioModule.dll", "UnityEngine.CoreModule.dll", "UnityEngine.JSONSerializeModule.dll", "UnityEngine.ParticleSystemModule.dll", "UnityEngine.PhysicsModule.dll", "UnityEngine.UIModule.dll" };

		public RestrictionMode namespaceRestrictionMode = RestrictionMode.Exclusive;

		public RestrictionMode assemblyRestrictionMode = RestrictionMode.Exclusive;

		public RestrictionMode typeReferenceRestrictionMode = RestrictionMode.Exclusive;

		public NamespaceRestriction[] namespaceRestrictions = new NamespaceRestriction[2]
		{
			new NamespaceRestriction("System.IO"),
			new NamespaceRestriction("System.Reflection")
		};

		public ReferenceRestriction[] referenceRestrictions = new ReferenceRestriction[2]
		{
			new ReferenceRestriction("UnityEditor.dll"),
			new ReferenceRestriction("Mono.Cecil.dll")
		};

		public TypeReferenceRestriction[] typeRestrictions = new TypeReferenceRestriction[1]
		{
			new TypeReferenceRestriction("UnityEngine.WWW")
		};

		public static DynamicCSharp Settings
		{
			get
			{
				if (instance == null)
				{
					instance = LoadSettings();
				}
				return instance;
			}
		}

		public static bool IsPlatformSupported
		{
			get
			{
				return true;
			}
		}

		public IEnumerable<Restriction> Restrictions
		{
			get
			{
				NamespaceRestriction[] array = namespaceRestrictions;
				for (int i = 0; i < array.Length; i++)
				{
					yield return array[i];
				}
				ReferenceRestriction[] array2 = referenceRestrictions;
				for (int i = 0; i < array2.Length; i++)
				{
					yield return array2[i];
				}
				TypeReferenceRestriction[] array3 = typeRestrictions;
				for (int i = 0; i < array3.Length; i++)
				{
					yield return array3[i];
				}
			}
		}

		public DynamicCSharp()
		{
			int num = assemblyReferences.Length;
			Array.Resize(ref assemblyReferences, num + unityAssemblyReferences.Length);
			for (int i = num; i < assemblyReferences.Length; i++)
			{
				assemblyReferences[i] = unityAssemblyReferences[i - num];
			}
		}

		internal BindingFlags GetTypeBindings()
		{
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
			if (discoverNonPublicTypes)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			return bindingFlags;
		}

		internal BindingFlags GetMemberBindings()
		{
			BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public;
			if (discoverNonPublicMembers)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			return bindingFlags;
		}

		private static DynamicCSharp LoadSettings()
		{
			UnityEngine.Object obj = Resources.Load("DynamicCSharp_Settings");
			if (obj != null)
			{
				return obj as DynamicCSharp;
			}
			Debug.LogWarning("DynamicCSharp: Failed to load settings - Default values will be used");
			return ScriptableObject.CreateInstance<DynamicCSharp>();
		}

		public static void SaveAsset(DynamicCSharp save)
		{
		}

		public static void LoadAsset()
		{
		}
	}
}
