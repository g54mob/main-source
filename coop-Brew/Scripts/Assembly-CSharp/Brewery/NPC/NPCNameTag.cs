using Brewery.NPC.Simple;
using UnityEngine;

namespace Brewery.NPC
{
	public class NPCNameTag : MonoBehaviour
	{
		[Header("Settings")]
		[Tooltip("Height offset above NPC")]
		[SerializeField]
		private float heightOffset;

		[Tooltip("Always show name tags (ignores AIStateLogger.Enabled)")]
		[SerializeField]
		private bool alwaysShow;

		[Tooltip("Show brain mode under name")]
		[SerializeField]
		private bool showBrainMode;

		[Tooltip("Text size")]
		[SerializeField]
		private float textSize;

		private GameObject tagObject;

		private TextMesh nameTextMesh;

		private TextMesh modeTextMesh;

		private SimpleNPCLifeBrain brain;

		private SimpleNPCController controller;

		private Camera mainCamera;

		private string npcName;

		private void Start()
		{
		}

		private void CreateTextMeshTag()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void OnEnable()
		{
		}
	}
}
