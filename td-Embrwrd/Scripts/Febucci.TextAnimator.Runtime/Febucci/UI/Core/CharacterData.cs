namespace Febucci.UI.Core
{
	public struct CharacterData
	{
		public CharInfo info;

		public int index;

		public int wordIndex;

		public bool isVisible;

		public float passedTime;

		public float uniformIntensity;

		public MeshData source;

		public MeshData current;

		public void ResetInfo(int i)
		{
		}

		public void ResetAnimation()
		{
		}

		public void Hide()
		{
		}

		public void UpdateIntensity(float referenceFontSize)
		{
		}
	}
}
