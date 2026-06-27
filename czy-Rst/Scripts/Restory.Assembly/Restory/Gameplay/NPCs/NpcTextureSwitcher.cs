using UnityEngine;

namespace Restory.Gameplay.NPCs
{
	public class NpcTextureSwitcher : MonoBehaviour
	{
		[SerializeField]
		private Renderer npcRenderer;

		[SerializeField]
		private string npcTexturePropertyName = "_Texture_Color";

		private int npcTexturePropertyID;

		private void Awake()
		{
			npcTexturePropertyID = Shader.PropertyToID(npcTexturePropertyName);
		}

		public void SetNpcTexture(Texture2D textureToSet)
		{
			npcRenderer.material.SetTexture(npcTexturePropertyID, textureToSet);
		}
	}
}
