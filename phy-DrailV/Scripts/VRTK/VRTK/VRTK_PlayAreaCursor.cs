using UnityEngine;
using UnityEngine.Rendering;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Pointers/VRTK_PlayAreaCursor")]
	public class VRTK_PlayAreaCursor : MonoBehaviour
	{
		[Header("Appearance Settings")]
		[Tooltip("If this is checked then the pointer valid/invalid colours will also be used to change the colour of the play area cursor when colliding/not colliding.")]
		public bool usePointerColor = true;

		[Tooltip("Determines the size of the play area cursor and collider. If the values are left as zero then the Play Area Cursor will be sized to the calibrated Play Area space.")]
		public Vector2 playAreaCursorDimensions = Vector2.zero;

		[Tooltip("If this is checked then if the play area cursor is colliding with any other object then the pointer colour will change to the `Pointer Miss Color` and the `DestinationMarkerSet` event will not be triggered, which will prevent teleporting into areas where the play area will collide.")]
		public bool handlePlayAreaCursorCollisions;

		[Tooltip("If this is checked then if the user's headset is outside of the play area cursor bounds then it is considered a collision even if the play area isn't colliding with anything.")]
		public bool headsetOutOfBoundsIsCollision;

		[Tooltip("If this is checked then the play area cursor will be displayed when the location is invalid.")]
		public bool displayOnInvalidLocation = true;

		[Tooltip("A specified VRTK_PolicyList to use to determine whether the play area cursor collisions will be acted upon.")]
		public VRTK_PolicyList targetListPolicy;

		[Header("Custom Settings")]
		[Tooltip("A custom Pointer Direction Indicator to use to determine the rotation of the Play Area Cursor.")]
		public VRTK_PointerDirectionIndicator directionIndicator;

		[Tooltip("A custom GameObject to use for the play area cursor representation for when the location is valid.")]
		public GameObject validLocationObject;

		[Tooltip("A custom GameObject to use for the play area cursor representation for when the location is invalid.")]
		public GameObject invalidLocationObject;

		protected bool headsetPositionCompensation;

		protected bool playAreaCursorCollided;

		protected bool headsetOutOfBounds;

		protected Transform playArea;

		protected GameObject playAreaCursor;

		protected GameObject[] playAreaCursorBoundaries;

		protected BoxCollider playAreaCursorCollider;

		protected Transform headset;

		protected Renderer[] boundaryRenderers = new Renderer[0];

		protected GameObject playAreaCursorValidChild;

		protected GameObject playAreaCursorInvalidChild;

		protected int btmRightInner;

		protected int btmLeftInner = 1;

		protected int topLeftInner = 2;

		protected int topRightInner = 3;

		protected int btmRightOuter = 4;

		protected int btmLeftOuter = 5;

		protected int topLeftOuter = 6;

		protected int topRightOuter = 7;

		public event PlayAreaCursorEventHandler PlayAreaCursorStartCollision;

		public event PlayAreaCursorEventHandler PlayAreaCursorEndCollision;

		public virtual void OnPlayAreaCursorStartCollision(PlayAreaCursorEventArgs e)
		{
			if (this.PlayAreaCursorStartCollision != null)
			{
				this.PlayAreaCursorStartCollision(this, e);
			}
		}

		public virtual void OnPlayAreaCursorEndCollision(PlayAreaCursorEventArgs e)
		{
			if (this.PlayAreaCursorEndCollision != null)
			{
				this.PlayAreaCursorEndCollision(this, e);
			}
		}

		public virtual bool HasCollided()
		{
			if (!playAreaCursorCollided)
			{
				return headsetOutOfBounds;
			}
			return true;
		}

		public virtual void SetHeadsetPositionCompensation(bool state)
		{
			headsetPositionCompensation = state;
		}

		public virtual void SetPlayAreaCursorCollision(bool state, Collider collider = null)
		{
			playAreaCursorCollided = false;
			if (handlePlayAreaCursorCollisions)
			{
				playAreaCursorCollided = base.enabled && state;
				EmitEvent(collider);
			}
		}

		public virtual void SetMaterialColor(Color color, bool validity)
		{
			if (validLocationObject == null)
			{
				ToggleVisibility(validity || displayOnInvalidLocation);
				if (usePointerColor)
				{
					for (int i = 0; i < playAreaCursorBoundaries.Length; i++)
					{
						SetCursorColor(playAreaCursorBoundaries[i], color);
					}
				}
			}
			else
			{
				ToggleValidPlayAreaState(!playAreaCursorCollided);
				if (usePointerColor)
				{
					SetCursorColor(playAreaCursor, color);
				}
			}
		}

		public virtual void SetPlayAreaCursorTransform(Vector3 location)
		{
			Vector3 vector = Vector3.zero;
			if (headsetPositionCompensation)
			{
				Vector3 vector2 = new Vector3(playArea.transform.position.x, 0f, playArea.transform.position.z);
				Vector3 vector3 = new Vector3(headset.position.x, 0f, headset.position.z);
				vector = vector2 - vector3;
			}
			if (!(playAreaCursor != null))
			{
				return;
			}
			if (playAreaCursor.activeInHierarchy && handlePlayAreaCursorCollisions && headsetOutOfBoundsIsCollision)
			{
				Vector3 point = new Vector3(location.x, playAreaCursor.transform.position.y + playAreaCursor.transform.localScale.y * 2f, location.z);
				if (!playAreaCursorCollider.bounds.Contains(point))
				{
					headsetOutOfBounds = true;
				}
				else
				{
					headsetOutOfBounds = false;
				}
			}
			playAreaCursor.transform.rotation = ((directionIndicator != null && directionIndicator.gameObject.activeInHierarchy) ? directionIndicator.transform.rotation : playArea.rotation);
			playAreaCursor.transform.position = location + vector;
		}

		public virtual void ToggleState(bool state)
		{
			state = base.enabled && state;
			if (playAreaCursor != null)
			{
				playAreaCursor.SetActive(state);
			}
		}

		public virtual bool IsActive()
		{
			if (!(playAreaCursor != null))
			{
				return false;
			}
			return playAreaCursor.activeInHierarchy;
		}

		public virtual GameObject GetPlayAreaContainer()
		{
			return playAreaCursor;
		}

		public virtual void ToggleVisibility(bool state)
		{
			if (playAreaCursor != null && boundaryRenderers.Length == 0)
			{
				boundaryRenderers = playAreaCursor.GetComponentsInChildren<Renderer>();
			}
			for (int i = 0; i < boundaryRenderers.Length; i++)
			{
				if (boundaryRenderers[i] != null)
				{
					boundaryRenderers[i].enabled = state;
				}
			}
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			VRTK_PlayerObject.SetPlayerObject(base.gameObject, VRTK_PlayerObject.ObjectTypes.Pointer);
			headset = VRTK_DeviceFinder.HeadsetTransform();
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			playAreaCursorBoundaries = new GameObject[4];
			InitPlayAreaCursor();
		}

		protected virtual void OnDisable()
		{
			if (playAreaCursor != null)
			{
				Object.Destroy(playAreaCursor);
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			if (base.enabled && IsActive())
			{
				UpdateCollider();
			}
		}

		protected virtual PlayAreaCursorEventArgs SetEventPayload(Collider collider)
		{
			PlayAreaCursorEventArgs result = default(PlayAreaCursorEventArgs);
			result.collider = collider;
			return result;
		}

		protected virtual void EmitEvent(Collider collider)
		{
			if (collider != null)
			{
				if (playAreaCursorCollided)
				{
					OnPlayAreaCursorStartCollision(SetEventPayload(collider));
				}
				else
				{
					OnPlayAreaCursorEndCollision(SetEventPayload(collider));
				}
			}
		}

		protected virtual void InitPlayAreaCursor()
		{
			if (playArea == null)
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.SDK_OBJECT_NOT_FOUND, "PlayArea", "Boundaries SDK"));
				return;
			}
			Vector3[] array = VRTK_SDK_Bridge.GetPlayAreaVertices();
			if (validLocationObject != null)
			{
				GeneratePlayAreaCursorFromPrefab(array);
			}
			else
			{
				if (array == null || array.Length < 8)
				{
					array = new Vector3[8]
					{
						new Vector3(0.8f, 0f, -0.8f),
						new Vector3(-0.8f, 0f, -0.8f),
						new Vector3(-0.8f, 0f, 0.8f),
						new Vector3(0.8f, 0f, 0.8f),
						new Vector3(1f, 0f, -1f),
						new Vector3(-1f, 0f, -1f),
						new Vector3(-1f, 0f, 1f),
						new Vector3(1f, 0f, 1f)
					};
				}
				GeneratePlayAreaCursor(array);
			}
			if (playAreaCursor != null)
			{
				playAreaCursor.SetActive(value: false);
				VRTK_PlayerObject.SetPlayerObject(playAreaCursor, VRTK_PlayerObject.ObjectTypes.Pointer);
				CreateCursorCollider(playAreaCursor);
				playAreaCursor.AddComponent<Rigidbody>().isKinematic = true;
				VRTK_PlayAreaCollider vRTK_PlayAreaCollider = playAreaCursor.AddComponent<VRTK_PlayAreaCollider>();
				vRTK_PlayAreaCollider.SetParent(this);
				vRTK_PlayAreaCollider.SetIgnoreTarget(targetListPolicy);
				playAreaCursor.layer = LayerMask.NameToLayer("Ignore Raycast");
			}
		}

		protected virtual void SetCursorColor(GameObject cursorObject, Color color)
		{
			Renderer componentInChildren = cursorObject.GetComponentInChildren<Renderer>();
			if (componentInChildren != null && (bool)componentInChildren.material && componentInChildren.material.HasProperty("_Color"))
			{
				componentInChildren.material.color = color;
				componentInChildren.shadowCastingMode = ShadowCastingMode.Off;
				componentInChildren.receiveShadows = false;
			}
		}

		protected virtual void ToggleValidPlayAreaState(bool state)
		{
			if (playAreaCursorValidChild != null)
			{
				playAreaCursorValidChild.SetActive(state);
			}
			if (playAreaCursorInvalidChild != null)
			{
				playAreaCursorInvalidChild.SetActive(displayOnInvalidLocation && !state);
			}
		}

		protected virtual string GeneratePlayAreaCursorName()
		{
			return VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "PlayAreaCursor");
		}

		protected virtual void GeneratePlayAreaCursorFromPrefab(Vector3[] cursorDrawVertices)
		{
			playAreaCursor = new GameObject(GeneratePlayAreaCursorName());
			float x = cursorDrawVertices[btmRightOuter].x - cursorDrawVertices[topLeftOuter].x;
			float z = cursorDrawVertices[topLeftOuter].z - cursorDrawVertices[btmRightOuter].z;
			if (playAreaCursorDimensions != Vector2.zero)
			{
				x = ((playAreaCursorDimensions.x == 0f) ? playAreaCursor.transform.localScale.x : playAreaCursorDimensions.x);
				z = ((playAreaCursorDimensions.y == 0f) ? playAreaCursor.transform.localScale.z : playAreaCursorDimensions.y);
			}
			float y = 0.01f;
			playAreaCursorValidChild = Object.Instantiate(validLocationObject);
			playAreaCursorValidChild.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, "ValidArea");
			playAreaCursorValidChild.transform.SetParent(playAreaCursor.transform);
			if (invalidLocationObject != null)
			{
				playAreaCursorInvalidChild = Object.Instantiate(invalidLocationObject);
				playAreaCursorInvalidChild.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, "InvalidArea");
				playAreaCursorInvalidChild.transform.SetParent(playAreaCursor.transform);
			}
			playAreaCursor.transform.localScale = new Vector3(x, y, z);
			playAreaCursorValidChild.transform.localScale = Vector3.one;
			if (invalidLocationObject != null)
			{
				playAreaCursorInvalidChild.transform.localScale = Vector3.one;
			}
			playAreaCursor.SetActive(value: false);
		}

		protected virtual void GeneratePlayAreaCursor(Vector3[] cursorDrawVertices)
		{
			if (playAreaCursorDimensions != Vector2.zero)
			{
				float playAreaBorderThickness = VRTK_SDK_Bridge.GetPlayAreaBorderThickness();
				cursorDrawVertices[btmRightOuter] = new Vector3(playAreaCursorDimensions.x / 2f, 0f, playAreaCursorDimensions.y / 2f * -1f);
				cursorDrawVertices[btmLeftOuter] = new Vector3(playAreaCursorDimensions.x / 2f * -1f, 0f, playAreaCursorDimensions.y / 2f * -1f);
				cursorDrawVertices[topLeftOuter] = new Vector3(playAreaCursorDimensions.x / 2f * -1f, 0f, playAreaCursorDimensions.y / 2f);
				cursorDrawVertices[topRightOuter] = new Vector3(playAreaCursorDimensions.x / 2f, 0f, playAreaCursorDimensions.y / 2f);
				cursorDrawVertices[btmRightInner] = cursorDrawVertices[btmRightOuter] + new Vector3(0f - playAreaBorderThickness, 0f, playAreaBorderThickness);
				cursorDrawVertices[btmLeftInner] = cursorDrawVertices[btmLeftOuter] + new Vector3(playAreaBorderThickness, 0f, playAreaBorderThickness);
				cursorDrawVertices[topLeftInner] = cursorDrawVertices[topLeftOuter] + new Vector3(playAreaBorderThickness, 0f, 0f - playAreaBorderThickness);
				cursorDrawVertices[topRightInner] = cursorDrawVertices[topRightOuter] + new Vector3(0f - playAreaBorderThickness, 0f, 0f - playAreaBorderThickness);
			}
			float x = cursorDrawVertices[btmRightOuter].x - cursorDrawVertices[topLeftOuter].x;
			float z = cursorDrawVertices[topLeftOuter].z - cursorDrawVertices[btmRightOuter].z;
			float num = 0.01f;
			playAreaCursor = new GameObject(GeneratePlayAreaCursorName());
			playAreaCursor.transform.SetParent(null);
			playAreaCursor.transform.localScale = new Vector3(x, num, z);
			float num2 = playArea.transform.localScale.x / 2f;
			float num3 = playArea.transform.localScale.z / 2f;
			float y = 0f;
			DrawPlayAreaCursorBoundary(0, cursorDrawVertices[btmLeftOuter].x, cursorDrawVertices[btmRightOuter].x, cursorDrawVertices[btmRightInner].z, cursorDrawVertices[btmRightOuter].z, num, new Vector3(0f, y, num3));
			DrawPlayAreaCursorBoundary(1, cursorDrawVertices[btmLeftOuter].x, cursorDrawVertices[btmLeftInner].x, cursorDrawVertices[topLeftOuter].z, cursorDrawVertices[btmLeftOuter].z, num, new Vector3(num2, y, 0f));
			DrawPlayAreaCursorBoundary(2, cursorDrawVertices[btmLeftOuter].x, cursorDrawVertices[btmRightOuter].x, cursorDrawVertices[btmRightInner].z, cursorDrawVertices[btmRightOuter].z, num, new Vector3(0f, y, 0f - num3));
			DrawPlayAreaCursorBoundary(3, cursorDrawVertices[btmLeftOuter].x, cursorDrawVertices[btmLeftInner].x, cursorDrawVertices[topLeftOuter].z, cursorDrawVertices[btmLeftOuter].z, num, new Vector3(0f - num2, y, 0f));
		}

		protected virtual void DrawPlayAreaCursorBoundary(int index, float left, float right, float top, float bottom, float thickness, Vector3 localPosition)
		{
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			gameObject.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "PlayAreaCursorBoundary", index);
			VRTK_PlayerObject.SetPlayerObject(gameObject, VRTK_PlayerObject.ObjectTypes.Pointer);
			float x = (right - left) / 1.065f;
			float z = (top - bottom) / 1.08f;
			gameObject.transform.localScale = new Vector3(x, thickness, z);
			Object.Destroy(gameObject.GetComponent<BoxCollider>());
			gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			gameObject.transform.SetParent(playAreaCursor.transform);
			gameObject.transform.localPosition = localPosition;
			playAreaCursorBoundaries[index] = gameObject;
		}

		protected virtual void CreateCursorCollider(GameObject cursor)
		{
			playAreaCursorCollider = cursor.AddComponent<BoxCollider>();
			playAreaCursorCollider.isTrigger = true;
			playAreaCursorCollider.center = new Vector3(0f, 65f, 0f);
			playAreaCursorCollider.size = new Vector3(1f, 1f, 1f);
		}

		protected virtual void UpdateCollider()
		{
			float num = 1f;
			float num2 = (headset.transform.position.y - playArea.transform.position.y) * 100f;
			float y = ((num2 != 0f) ? (num2 / 2f + num) : 0f);
			playAreaCursorCollider.size = new Vector3(playAreaCursorCollider.size.x, num2, playAreaCursorCollider.size.z);
			playAreaCursorCollider.center = new Vector3(playAreaCursorCollider.center.x, y, playAreaCursorCollider.center.z);
		}
	}
}
