using UnityEngine;

public class FullCycleUnitTest : MonoBehaviour
{
	public TextureHandeler _txhTextureHandeler;

	[Range(1f, 12f)]
	public int TextureSizeX;

	[Range(1f, 12f)]
	public int TextureSizeY;

	public int iSeed;

	public int _iNumberOfPointsToCheck;

	public Color _colNoVisitColour;

	public Color _colVisitOnceColour;

	public Color _colVisitTwiceColour;

	[ContextMenu("Full Cycle Test")]
	public void FullCycleTest()
	{
		int num = (int)Mathf.Pow(2f, TextureSizeX);
		int num2 = (int)Mathf.Pow(2f, TextureSizeY);
		FullCycleGenerator fullCycleGenerator = new FullCycleGenerator();
		iSeed = Random.Range(0, int.MaxValue);
		fullCycleGenerator.Setup(iSeed, num * num2);
		if (_txhTextureHandeler == null)
		{
			_txhTextureHandeler = new TextureHandeler();
		}
		_txhTextureHandeler.Initalise(num, num2, _colNoVisitColour);
		for (int i = 0; i < _iNumberOfPointsToCheck; i++)
		{
			int iPixleIndex = fullCycleGenerator.NextInt();
			Color pixle = _txhTextureHandeler.GetPixle(iPixleIndex);
			Color colColour = _colVisitOnceColour;
			if (pixle == _colNoVisitColour)
			{
				colColour = _colVisitOnceColour;
			}
			if (pixle == _colVisitOnceColour)
			{
				colColour = _colVisitTwiceColour;
			}
			_txhTextureHandeler.SetPixle(iPixleIndex, colColour);
		}
		_txhTextureHandeler.Apply();
	}
}
