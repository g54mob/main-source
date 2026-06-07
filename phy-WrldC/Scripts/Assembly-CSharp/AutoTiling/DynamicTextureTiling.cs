namespace AutoTiling
{
	public class DynamicTextureTiling : AutoTextureTiling
	{
		private void Update()
		{
			if (scaleX != base.transform.lossyScale.x || scaleY != base.transform.lossyScale.y || scaleZ != base.transform.lossyScale.z)
			{
				scaleX = base.transform.lossyScale.x;
				scaleY = base.transform.lossyScale.y;
				scaleZ = base.transform.lossyScale.z;
				CreateMeshAndUVs();
			}
		}
	}
}
