using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials
{
	public class TutorialPartScript : MonoBehaviour
	{
		[SerializeField]
		private bool _isHiddenPart;

		[SerializeField]
		private bool _isUserAddedPart = true;

		[SerializeField]
		private PartScript _partScript;

		public bool IsHiddenPart
		{
			get
			{
				return _isHiddenPart;
			}
			set
			{
				_isHiddenPart = value;
			}
		}

		public bool IsUserAddedPart
		{
			get
			{
				return _isUserAddedPart;
			}
			set
			{
				_isUserAddedPart = value;
			}
		}

		public PartScript PartScript => _partScript;

		public static TutorialPartScript Create(GameObject obj, bool isUserAddedPart = true, bool isHiddenPart = false)
		{
			TutorialPartScript tutorialPartScript = obj.AddComponent<TutorialPartScript>();
			tutorialPartScript.IsUserAddedPart = isUserAddedPart;
			tutorialPartScript.IsHiddenPart = isHiddenPart;
			return tutorialPartScript;
		}

		protected virtual void Awake()
		{
			_partScript = GetComponent<PartScript>();
			if (_partScript == null)
			{
				Debug.LogError("TutorialPartScript on GameObject '" + base.gameObject.name + "' is missing a PartScript component reference.");
			}
		}
	}
}
