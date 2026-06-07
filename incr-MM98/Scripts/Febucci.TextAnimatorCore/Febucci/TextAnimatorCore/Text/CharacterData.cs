using Febucci.Numbers;

namespace Febucci.TextAnimatorCore.Text
{
	public struct CharacterData
	{
		public CharInfo info;

		public int index;

		public int wordIndex;

		public bool isVisible;

		public float appearTime;

		public float visibleTime;

		public float disappearTime;

		internal float uniformIntensity;

		internal Vector3 originalCenter;

		public MeshData source;

		public MeshData current;

		public const int VERTICES_PER_CHAR = 4;

		public void ResetInfo(int i, bool resetVisibility = true)
		{
			index = i;
			wordIndex = -1;
			uniformIntensity = 1f;
			if (resetVisibility)
			{
				isVisible = true;
			}
			if (!info.initialized)
			{
				source = new MeshData(true);
				current = new MeshData(true);
				info.initialized = true;
			}
		}

		public void ResetAnimation()
		{
			if (source.positions != null && current.positions != null)
			{
				current.positions[0] = source.positions[0];
				current.positions[1] = source.positions[1];
				current.positions[2] = source.positions[2];
				current.positions[3] = source.positions[3];
				current.colors[0] = source.colors[0];
				current.colors[1] = source.colors[1];
				current.colors[2] = source.colors[2];
				current.colors[3] = source.colors[3];
				originalCenter = this.GetCenter();
			}
		}

		public void Hide()
		{
			visibleTime = 0f;
			if (current.positions != null)
			{
				for (int i = 0; i < 4; i++)
				{
					current.positions[i] = Vector3.Zero;
				}
			}
		}

		public void UpdateIntensity(float referenceFontSize)
		{
			if (referenceFontSize == 0f)
			{
				uniformIntensity = 1f;
			}
			else
			{
				uniformIntensity = info.pointSize / referenceFontSize;
			}
		}
	}
}
