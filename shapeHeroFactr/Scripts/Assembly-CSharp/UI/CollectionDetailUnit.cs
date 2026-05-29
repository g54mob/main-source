using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class CollectionDetailUnit : ChoiceMenuButtonBase
	{
		public eLuggage luggage;

		public Image dummyImage;

		public GameObject unlockText;

		public Image needCountBG;

		public TMP_Text needCountText;

		public RawImage emphasisEffectImage;

		public GameObject padGuide;

		private static readonly int PROPERTY_IS_SECRET;

		private PlayUnlockData _unlockData;

		private eDialog _member;

		private InputActionController input;

		public bool IsSecret { get; private set; }

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Init(eDialog member = eDialog.None, eLuggage luggage = eLuggage.None, eLuggage target = eLuggage.None)
		{
		}

		public void MouseOver()
		{
		}

		public void MouseExit()
		{
		}
	}
}
