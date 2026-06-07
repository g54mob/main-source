using UnityEngine;

namespace MagicaCloth2
{
	public class RuntimeBuildDemo : MonoBehaviour
	{
		[SerializeField]
		private GameObject characterPrefab;

		[SerializeField]
		private MagicaCloth frontHairSource;

		[SerializeField]
		private string ribbonPresetName;

		[SerializeField]
		private string skirtName;

		[SerializeField]
		private Texture2D skirtPaintMap;

		private GameObject character;

		private GameObjectContainer gameObjectContainer;

		protected void Start()
		{
		}

		public void OnCreateButton()
		{
		}

		public void OnRemoveButton()
		{
		}

		private void GenerateCharacter()
		{
		}

		private void SetupHairTail_BoneCloth()
		{
		}

		private void SetupFrontHair_BoneCloth()
		{
		}

		private void SetupRibbon_BoneCloth()
		{
		}

		private void SetupSkirt_MeshCloth()
		{
		}
	}
}
