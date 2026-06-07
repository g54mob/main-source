namespace LeTai.Asset.TranslucentImage
{
	public interface IActiveRegionProvider
	{
		bool HaveActiveRegion();

		void GetActiveRegion(VPMatrixCache vpMatrixCache, out ActiveRegion activeRegion);
	}
}
