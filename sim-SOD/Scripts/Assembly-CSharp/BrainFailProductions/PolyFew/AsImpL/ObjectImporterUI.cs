using UnityEngine;
using UnityEngine.UI;

namespace BrainFailProductions.PolyFew.AsImpL
{
	[RequireComponent(typeof(ObjectImporter))]
	public class ObjectImporterUI : MonoBehaviour
	{
		[Tooltip("Text for activity messages")]
		public Text progressText;

		[Tooltip("Slider for the overall progress")]
		public Slider progressSlider;

		[Tooltip("Panel with the Image Type set to Filled")]
		public Image progressImage;

		private ObjectImporter objImporter;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void OnImportStart()
		{
		}

		private void OnImportComplete()
		{
		}
	}
}
