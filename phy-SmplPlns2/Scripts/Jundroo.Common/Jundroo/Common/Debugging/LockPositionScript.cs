using UnityEngine;

namespace Jundroo.Common.Debugging
{
	public class LockPositionScript : MonoBehaviour
	{
		private bool _editorBuildCheck;

		[SerializeField]
		private Vector3 _position = Vector3.zero;

		[SerializeField]
		private bool _useWorldPosition;

		public Vector3 Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}

		public bool UseWorldPosition
		{
			get
			{
				return _useWorldPosition;
			}
			set
			{
				_useWorldPosition = value;
			}
		}

		public static LockPositionScript Add(GameObject obj, Vector3 position, bool useWorldPosition)
		{
			LockPositionScript lockPositionScript = obj.AddComponent<LockPositionScript>();
			lockPositionScript.Position = position;
			lockPositionScript.UseWorldPosition = useWorldPosition;
			return lockPositionScript;
		}

		protected virtual void Awake()
		{
			SetPosition();
		}

		protected virtual void FixedUpdate()
		{
			SetPosition();
		}

		protected virtual void LateUpdate()
		{
			SetPosition();
		}

		protected virtual void OnEnable()
		{
			SetPosition();
		}

		protected virtual void Update()
		{
			SetPosition();
		}

		private void SetPosition()
		{
			if (!_editorBuildCheck)
			{
				_editorBuildCheck = true;
				if (!Application.isEditor)
				{
					Debug.LogError("Script '" + GetType().FullName + "' on object '" + base.gameObject.name + "' is only meant to be used in the Unity editor.");
				}
			}
			if (_useWorldPosition)
			{
				base.transform.position = _position;
			}
			else
			{
				base.transform.localPosition = _position;
			}
		}
	}
}
