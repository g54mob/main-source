using UnityEngine;

namespace UI
{
	public class SpellAutoSwitchButton : MonoBehaviour
	{
		[SerializeField]
		private RectTransform layoutRect;

		[SerializeField]
		private Sprite offImage;

		[SerializeField]
		private Sprite onImage;

		public EmphasisObj emphasis;

		private bool previousAutoMiracleValue;

		public void OnSwitchAutoSpell()
		{
		}

		private void UpdateButtonImage(bool on)
		{
		}

		public void OnDisable()
		{
		}

		public void OnEnable()
		{
		}

		public void OnChangeLocalize()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
