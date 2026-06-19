using FullInspector;
using JetBrains.Annotations;

namespace TH20.ExtContent
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ExtContentConfig
	{
		public SharedInstance<GameItemPicture.GameItemPictureConfig>[] _configPictures;

		public SharedInstance<GameItemRug.GameItemRugConfig>[] _configRugs;

		public SharedInstance<GameItemRug.GameItemRugConfig>[] _configFloors;

		public SharedInstance<GameItemRug.GameItemRugConfig>[] _configWalls;

		public SharedInstance<GameItemMusicPack.GameItemMusicPackConfig> _configMusicPack;
	}
}
