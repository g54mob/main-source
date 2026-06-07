using UnityEngine;
using UnityEngine.UI;

namespace UMA.Examples
{
	public class UMASlotVerifyWizard : MonoBehaviour
	{
		private GameObject RaceGO;

		private SkinnedMeshRenderer RaceSMR;

		private GameObject SlotGO;

		private SkinnedMeshRenderer SlotSMR;

		public GameObject[] Pages;

		public int page;

		public Text resultText;

		private Object slotAsset;

		public Button ForceButton;

		private bool forcedSlotBones;

		private string slotAssetPath;

		private void NextPage()
		{
		}

		private void SetPage(int newPage)
		{
		}

		public void SelectMaleClick()
		{
		}

		public void SelectFemaleClick()
		{
		}

		public void BrowseBaseMeshClick()
		{
		}

		public void BrowseSlotMeshClick()
		{
		}

		public void SelectNewBaseMesh()
		{
		}

		public void SelectNewSlotMesh()
		{
		}

		public void ForceSkeleton()
		{
		}
	}
}
