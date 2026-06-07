using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Multiplayer;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Assets.Scripts.Character.Camera
{
	public class CharacterCameraVantage : MonoBehaviour
	{
		private CharacterActor _character;

		private Transform _followBone;

		[SerializeField]
		private string _followBonePath = string.Empty;

		[SerializeField]
		private ViewMode _mode = ViewMode.FirstPerson;

		[SerializeField]
		private Renderer[] _shadowsOnlyRenderers;

		[SerializeField]
		[Tooltip("Whether to skip following logic. Check this if the camera vantage should not follow another transform.")]
		private bool _skipFollowLogic = true;

		[SerializeField]
		private float _verticalOffsetFromBone;

		public ViewMode Mode => _mode;

		public Renderer[] ShadowOnlyRenderers => _shadowsOnlyRenderers;

		protected void LateUpdate()
		{
			if (!_skipFollowLogic)
			{
				CheckFollowBone();
				if (_followBone != null)
				{
					Vector3 vector = base.transform.parent.InverseTransformPoint(_followBone.position);
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, vector.y + _verticalOffsetFromBone, base.transform.localPosition.z);
				}
			}
		}

		protected void OnEnable()
		{
			_character = GetComponentInParent<CharacterActor>();
			NetworkCharacterScript componentInParent = GetComponentInParent<NetworkCharacterScript>();
			if (componentInParent != null && !componentInParent.IsOwner)
			{
				_skipFollowLogic = true;
			}
			else if (!string.IsNullOrWhiteSpace(_followBonePath))
			{
				_skipFollowLogic = false;
			}
		}

		private void CheckFollowBone()
		{
			if (!(_followBone == null) || string.IsNullOrWhiteSpace(_followBonePath))
			{
				return;
			}
			Transform parent = base.transform.parent;
			if (_character != null)
			{
				parent = _character.Animator.transform;
			}
			if (parent != null)
			{
				_followBone = parent.Find(_followBonePath);
				if (_followBone == null)
				{
					Debug.LogWarning("Character camera vantage couldn't find transform to follow at path " + _followBonePath, this);
					_skipFollowLogic = true;
				}
			}
			else
			{
				Debug.LogWarning("Character camera vantage has no parent, can't search for transform to follow.", this);
				_skipFollowLogic = true;
			}
		}
	}
}
