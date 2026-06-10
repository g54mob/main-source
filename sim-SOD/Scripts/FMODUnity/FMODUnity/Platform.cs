using System;
using System.Collections.Generic;
using FMOD;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Serialization;

namespace FMODUnity
{
	public abstract class Platform : ScriptableObject
	{
		public class Property<T>
		{
			public T Value;

			public bool HasValue;
		}

		[Serializable]
		public class PropertyBool : Property<TriStateBool>
		{
		}

		[Serializable]
		public class PropertyInt : Property<int>
		{
		}

		[Serializable]
		public class PropertySpeakerMode : Property<SPEAKERMODE>
		{
		}

		[Serializable]
		public class PropertyString : Property<string>
		{
		}

		[Serializable]
		public class PropertyStringList : Property<List<string>>
		{
		}

		[Serializable]
		public class PropertyCallbackHandler : Property<PlatformCallbackHandler>
		{
		}

		public interface PropertyOverrideControl
		{
			bool HasValue(Platform platform);

			void Clear(Platform platform);
		}

		public struct PropertyAccessor<T> : PropertyOverrideControl
		{
			private readonly Func<PropertyStorage, Property<T>> Getter;

			private readonly T DefaultValue;

			public PropertyAccessor(Func<PropertyStorage, Property<T>> getter, T defaultValue)
			{
				Getter = null;
				DefaultValue = default(T);
			}

			public bool HasValue(Platform platform)
			{
				return false;
			}

			public T Get(Platform platform)
			{
				return default(T);
			}

			public void Set(Platform platform, T value)
			{
			}

			public void Clear(Platform platform)
			{
			}
		}

		[Serializable]
		public class PropertyStorage
		{
			public PropertyBool LiveUpdate;

			public PropertyInt LiveUpdatePort;

			public PropertyBool Overlay;

			public PropertyBool Logging;

			public PropertyInt SampleRate;

			public PropertyString BuildDirectory;

			public PropertySpeakerMode SpeakerMode;

			public PropertyInt VirtualChannelCount;

			public PropertyInt RealChannelCount;

			public PropertyInt DSPBufferLength;

			public PropertyInt DSPBufferCount;

			public PropertyStringList Plugins;

			public PropertyStringList StaticPlugins;

			public PropertyCallbackHandler CallbackHandler;
		}

		public static class PropertyAccessors
		{
			public static readonly PropertyAccessor<TriStateBool> LiveUpdate;

			public static readonly PropertyAccessor<int> LiveUpdatePort;

			public static readonly PropertyAccessor<TriStateBool> Overlay;

			public static readonly PropertyAccessor<TriStateBool> Logging;

			public static readonly PropertyAccessor<int> SampleRate;

			public static readonly PropertyAccessor<string> BuildDirectory;

			public static readonly PropertyAccessor<SPEAKERMODE> SpeakerMode;

			public static readonly PropertyAccessor<int> VirtualChannelCount;

			public static readonly PropertyAccessor<int> RealChannelCount;

			public static readonly PropertyAccessor<int> DSPBufferLength;

			public static readonly PropertyAccessor<int> DSPBufferCount;

			public static readonly PropertyAccessor<List<string>> Plugins;

			public static readonly PropertyAccessor<List<string>> StaticPlugins;

			public static readonly PropertyAccessor<PlatformCallbackHandler> CallbackHandler;
		}

		[Serializable]
		public class PropertyThreadAffinityList : Property<List<ThreadAffinityGroup>>
		{
		}

		[Serializable]
		public class PropertyCodecChannels : Property<List<CodecChannelCount>>
		{
		}

		public const float DefaultPriority = 0f;

		public const string RegisterStaticPluginsClassName = "StaticPluginManager";

		public const string RegisterStaticPluginsFunctionName = "Register";

		[SerializeField]
		private string identifier;

		[SerializeField]
		private string parentIdentifier;

		[SerializeField]
		private bool active;

		[SerializeField]
		protected PropertyStorage Properties;

		[FormerlySerializedAs("outputType")]
		[SerializeField]
		public string OutputTypeName;

		private static List<ThreadAffinityGroup> StaticThreadAffinities;

		[SerializeField]
		private PropertyThreadAffinityList threadAffinities;

		[NonSerialized]
		public Platform Parent;

		private static List<CodecChannelCount> staticCodecChannels;

		[SerializeField]
		private PropertyCodecChannels codecChannels;

		public string Identifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public abstract string DisplayName { get; }

		public virtual float Priority => 0f;

		public virtual bool MatchesCurrentEnvironment => false;

		public virtual bool IsIntrinsic => false;

		public string ParentIdentifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsLiveUpdateEnabled => false;

		public bool IsOverlayEnabled => false;

		public bool Active => false;

		public bool HasAnyOverriddenProperties => false;

		public TriStateBool LiveUpdate => default(TriStateBool);

		public int LiveUpdatePort => 0;

		public TriStateBool Overlay => default(TriStateBool);

		public TriStateBool Logging => default(TriStateBool);

		public int SampleRate => 0;

		public string BuildDirectory => null;

		public SPEAKERMODE SpeakerMode => default(SPEAKERMODE);

		public int VirtualChannelCount => 0;

		public int RealChannelCount => 0;

		public int DSPBufferLength => 0;

		public int DSPBufferCount => 0;

		public List<string> Plugins => null;

		public List<string> StaticPlugins => null;

		public PlatformCallbackHandler CallbackHandler => null;

		public virtual List<ThreadAffinityGroup> DefaultThreadAffinities => null;

		public IEnumerable<ThreadAffinityGroup> ThreadAffinities => null;

		public PropertyThreadAffinityList ThreadAffinitiesProperty => null;

		public virtual List<CodecChannelCount> DefaultCodecChannels => null;

		public List<CodecChannelCount> CodecChannels => null;

		public PropertyCodecChannels CodecChannelsProperty => null;

		public abstract void DeclareRuntimePlatforms(Settings settings);

		public virtual void PreSystemCreate(Action<RESULT, string> reportResult)
		{
		}

		public virtual void PreInitialize(FMOD.Studio.System studioSystem)
		{
		}

		public virtual string GetBankFolder()
		{
			return null;
		}

		protected virtual string GetPluginBasePath()
		{
			return null;
		}

		public virtual string GetPluginPath(string pluginName)
		{
			return null;
		}

		public virtual void LoadPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
		}

		public virtual void LoadDynamicPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
		}

		public virtual void LoadStaticPlugins(FMOD.System coreSystem, Action<RESULT, string> reportResult)
		{
		}

		public void AffirmProperties()
		{
		}

		public void ClearProperties()
		{
		}

		public virtual void InitializeProperties()
		{
		}

		public virtual void EnsurePropertiesAreValid()
		{
		}

		public bool InheritsFrom(Platform platform)
		{
			return false;
		}

		public OUTPUTTYPE GetOutputType()
		{
			return default(OUTPUTTYPE);
		}
	}
}
