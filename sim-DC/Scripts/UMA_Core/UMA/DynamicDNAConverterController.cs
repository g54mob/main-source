using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class DynamicDNAConverterController : ScriptableObject, IDNAConverter, IDynamicDNAConverter
	{
		[SerializeField]
		[Tooltip("A DNA Asset defines the names that will be available to the DNA Converters when modifying the Avatar. Often displayed in the UI as 'sliders'. Click the 'Inspect' button to view the assigned asset")]
		private DynamicUMADnaAsset _dnaAsset;

		[SerializeField]
		private List<DynamicDNAPlugin> _plugins;

		[SerializeField]
		[BaseCharacterModifier.Config(true)]
		[Tooltip("Overall Modifiers apply to ALL characters that use this converter. You use this to make a Female race shorter than a Male race for example. They can change an entire races base scale, height and radius (used for fitting the collider), its mass, and update its bounds.  Its elements can selectively be enabled and are calculated after all other DNA Converters have made changes to the avatar. Usually you only use these once per race, on the base 'Converter Controller' for the race.")]
		private BaseCharacterModifier _overallModifiers;

		private List<string> _usedDNANames;

		[SerializeField]
		[Tooltip("A 'nice name' to use when Categorizing DNASetters in the UI")]
		private string _displayValue;

		[NonSerialized]
		private List<DynamicDNAPlugin> _applyDNAPostpassPlugins;

		[NonSerialized]
		private List<DynamicDNAPlugin> _applyDNAPrepassPlugins;

		[NonSerialized]
		private List<DynamicDNAPlugin> _applyDNAPlugins;

		[NonSerialized]
		private bool _prepared;

		private Dictionary<string, List<UnityAction<string, float>>> _dnaCallbackDelegates;

		public string DisplayValue => null;

		public Type DNAType => null;

		public int DNATypeHash => 0;

		public DNAConvertDelegate PreApplyDnaAction => null;

		public DNAConvertDelegate PostApplyDnaAction => null;

		public DNAConvertDelegate ApplyDnaAction => null;

		public DynamicUMADnaAsset dnaAsset => null;

		public DynamicUMADnaAsset DNAAsset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int PluginCount => 0;

		public BaseCharacterModifier overallModifiers => null;

		public float liveScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float baseScale => 0f;

		string IDNAConverter.name => null;

		public void Prepare()
		{
		}

		public bool AddDnaCallbackDelegate(UnityAction<string, float> callback, string targetDnaName)
		{
			return false;
		}

		public bool RemoveDnaCallbackDelegate(UnityAction<string, float> callback, string targetDnaName)
		{
			return false;
		}

		public void ApplyDNAPrepass(UMAData umaData, UMASkeleton skeleton)
		{
		}

		public void ApplyDNAPostpass(UMAData umaData, UMASkeleton skeleton)
		{
		}

		public void ApplyDNA(UMAData umaData, UMASkeleton skeleton)
		{
		}

		public void ApplyAdjustScale(UMAData umaData)
		{
		}

		public void ApplyHeightMassRadius(UMAData umaData)
		{
		}

		public void ApplyDnaCallbackDelegates(UMAData umaData)
		{
		}

		public List<string> GetUsedDNANames(bool forceRefresh = false)
		{
			return null;
		}

		public DynamicDNAPlugin GetPlugin(int index)
		{
			return null;
		}

		public DynamicDNAPlugin GetPlugin(string name)
		{
			return null;
		}

		public List<DynamicDNAPlugin> GetPlugins()
		{
			return null;
		}

		public List<DynamicDNAPlugin> GetPlugins(Type pluginType)
		{
			return null;
		}

		public DynamicDNAPlugin AddPlugin(Type pluginType)
		{
			return null;
		}

		public bool DeletePlugin(DynamicDNAPlugin pluginToDelete)
		{
			return false;
		}

		public void ValidatePlugins()
		{
		}

		private void CompileUsedDNANamesList()
		{
		}

		private static DynamicDNAPlugin CreatePlugin(Type pluginType, DynamicDNAConverterController converter)
		{
			return null;
		}

		public string GetUniquePluginName(string desiredName, DynamicDNAPlugin existingPlugin = null)
		{
			return null;
		}
	}
}
