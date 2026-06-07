using UnityEngine;

namespace Gh.Tk
{
	public class CharacterColorAssigned : MonoBehaviour
	{
		public Color hair;

		public Color primarySkin;

		public Color secondarySkin;

		public Texture2D skinPixels;

		public Texture2D secondarySkinPixels;

		public Texture2D hairPixels;

		private Rect _sourceRect;

		private Texture2D _characterTexture;

		private SkinnedMeshRenderer _bodyMesh;

		private SkinnedMeshRenderer _headMesh;

		private Texture2D _destTex;

		private Material _characterMat;

		public bool realTimeUpdate;

		private void Start()
		{
		}

		public void ApplyCharacterColors()
		{
		}

		private void Update()
		{
		}
	}
}
