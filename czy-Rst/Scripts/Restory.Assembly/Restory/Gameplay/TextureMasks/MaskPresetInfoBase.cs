using Mandragora.PWS;
using Restory.Data.Base;

namespace Restory.Gameplay.TextureMasks
{
	public abstract class MaskPresetInfoBase : RestoryEntityInfoBase
	{
		public abstract ChannelGenerationEntry RedChannel { get; }

		public abstract ChannelGenerationEntry GreenChannel { get; }

		public abstract ChannelGenerationEntry BlueChannel { get; }

		public abstract bool IsInDebugMode { get; }

		public abstract float PredefinedSeed { get; }
	}
}
