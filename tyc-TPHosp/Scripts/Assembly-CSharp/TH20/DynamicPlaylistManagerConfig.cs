using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DynamicPlaylistManagerConfig
	{
		public bool _bAllowAudioInfoUpdateOnImport;

		public bool _bAllowUnnormalisedPreviews = true;

		public bool _bPerformTrackNormalisation = true;

		public bool _bUseRMSNormalisation;

		public float _normalisationdB = -16f;

		public float _unnormalisedPlaybackdB;

		public int _maxSongAndArtistNameLength = 64;

		public int _updateAudioInfoProcessSizeKb = 64;

		public bool _allowLocalModCreationPC = true;

		public bool _allowLocalModCreationMAC = true;

		public bool _allowLocalModCreationLINUX = true;

		public bool _allowExtContentSourceItemsPC = true;

		public bool _allowExtContentSourceItemsMAC = true;

		public bool _allowExtContentSourceItemsLINUX = true;
	}
}
