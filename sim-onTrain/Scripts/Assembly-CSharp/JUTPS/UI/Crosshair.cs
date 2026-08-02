using System.Collections.Generic;
using JUTPS.CameraSystems;
using JUTPS.CharacterBrain;
using JUTPS.JUInputSystem;
using JUTPS.WeaponSystem;
using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.UI
{
	[AddComponentMenu("JU TPS/UI/Crosshair")]
	public class Crosshair : MonoBehaviour
	{
		public static Crosshair Instance;

		public static bool AimingOnTarget;

		public static bool AimingOnFriend;

		public static GameObject ObjectOnCrosshairPoint;

		private JUCameraController cameraController;

		private JUCharacterController player;

		[Header("Settings")]
		public float CrosshairSensibility = 6f;

		public float CrosshairChangeSpeed = 4f;

		private float SmoothedWeaponPrecision;

		[Header("Hide Settings")]
		public bool FollowMousePosition;

		public bool HideOnNoWeaponUsing;

		public bool HideOnAiming;

		public bool OnlyShowOnFireMode;

		[Header("Visual Settings")]
		public Image[] Crosshairs;

		private Image CrosshairCenterPoint;

		private Canvas ParentCanvas;

		[HideInInspector]
		public List<Vector3> CrosshairsStartPositions = new List<Vector3>();

		[HideInInspector]
		public Vector3 CrosshairStartScale;

		public bool ChangeColor = true;

		public bool FilterPlayer = true;

		public string[] TargetTags = new string[8] { "Enemy", "Skin", "Vehicle", "Zombie", "Monster", "Destructible", "Shootable", "Player" };

		public string[] NoShootableTags = new string[2] { "Friend", "Unshootable" };

		public Color NormalColor = Color.white;

		public Color ShootableColor = Color.red;

		public Color NonShootableColor = new Color(1f, 1f, 1f, 0.3f);

		private bool isInitialized;

		private void OnEnable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		}

		protected virtual void Initialize(TSPlayerController tsPlayer)
		{
			if (!isInitialized)
			{
				Instance = this;
				player = tsPlayer.GetComponent<JUCharacterController>();
				if (!(player == null))
				{
					CrosshairsStartPositions = GetCrosshairPositions(Crosshairs);
					CrosshairStartScale = Crosshairs[0].transform.localScale;
					CrosshairCenterPoint = GetComponent<Image>();
					ParentCanvas = GetComponentInParent<Canvas>();
				}
			}
		}

		protected virtual void Update()
		{
			if (!(player == null))
			{
				UpdateObjectOnCrosshairPoint();
				UpdateCrosshairColor();
				UpdateCrosshair();
			}
		}

		protected virtual void UpdateCrosshair()
		{
			if (Crosshairs.Length != 0)
			{
				Weapon weaponInUse = ((player.WeaponInUseLeftHand == null) ? player.WeaponInUseRightHand : player.WeaponInUseLeftHand);
				SmoothedWeaponPrecision = GetWeaponPrecisionValue(SmoothedWeaponPrecision, weaponInUse, CrosshairChangeSpeed);
				if (Crosshairs.Length > 1)
				{
					MoveTowardsCenter(Crosshairs, CrosshairsStartPositions, SmoothedWeaponPrecision);
				}
				else
				{
					ResizeCrosshair(Crosshairs[0], SmoothedWeaponPrecision);
				}
				if (OnlyShowOnFireMode)
				{
					SetActiveCrosshair(!player.IsAiming && player.FiringMode);
				}
				else
				{
					HideCrosshairOnNoWeaponUsing();
					HideCrosshairOnAiming();
				}
				if (FollowMousePosition && JUInput.Instance().InputActions != null)
				{
					Vector2 screenPoint = JUInput.Instance().InputActions.Player.MousePosition.ReadValue<Vector2>();
					RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentCanvas.transform as RectTransform, screenPoint, ParentCanvas.worldCamera, out var localPoint);
					Vector3 position = ParentCanvas.transform.TransformPoint(localPoint);
					CrosshairCenterPoint.transform.position = position;
					base.transform.position = position;
				}
			}
		}

		protected virtual void UpdateCrosshairColor()
		{
			if (!ChangeColor)
			{
				return;
			}
			Color currentCrosshairColor = GetCurrentCrosshairColor(ObjectOnCrosshairPoint);
			if (Crosshairs.Length > 1)
			{
				Image[] crosshairs = Crosshairs;
				for (int i = 0; i < crosshairs.Length; i++)
				{
					crosshairs[i].color = currentCrosshairColor;
				}
			}
			else
			{
				Crosshairs[0].color = currentCrosshairColor;
			}
			CrosshairCenterPoint.color = currentCrosshairColor;
		}

		protected virtual void UpdateObjectOnCrosshairPoint()
		{
			if (cameraController == null)
			{
				ObjectOnCrosshairPoint = null;
				return;
			}
			GetObjectOnCrosshairPoint(cameraController.mCamera, cameraController.CrosshairRaycastLayerMask, out ObjectOnCrosshairPoint);
			if (ObjectOnCrosshairPoint != null && FilterPlayer && ObjectOnCrosshairPoint.layer == 15)
			{
				JUCharacterBrain componentInParent = ObjectOnCrosshairPoint.GetComponentInParent<JUCharacterBrain>();
				if (componentInParent != null && cameraController == componentInParent.MyPivotCamera)
				{
					ObjectOnCrosshairPoint = null;
				}
			}
		}

		private void OnDisable()
		{
			ObjectOnCrosshairPoint = null;
			Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.RemoveListener(Initialize);
		}

		public Color GetCurrentCrosshairColor(GameObject ObjectOnCrosshairPoint)
		{
			Color result = NormalColor;
			if (ObjectOnCrosshairPoint == null)
			{
				return result;
			}
			if (IsAimingOnNonShootableObject(ObjectOnCrosshairPoint, NoShootableTags))
			{
				result = NonShootableColor;
			}
			if (IsAimingOnShootableObject(ObjectOnCrosshairPoint, TargetTags))
			{
				result = ShootableColor;
			}
			return result;
		}

		public static void GetObjectOnCrosshairPoint(Camera camera, LayerMask CrosshairRaycastLayerMask, out GameObject ObjectOnMousePosition)
		{
			ObjectOnMousePosition = null;
			if (Physics.Raycast(camera.ScreenPointToRay(JUInput.GetMousePosition()), out var hitInfo, 1000f, CrosshairRaycastLayerMask))
			{
				ObjectOnMousePosition = hitInfo.collider.gameObject;
			}
		}

		public static bool IsAimingOnShootableObject(GameObject ObjectOnMousePosition, string[] TargetList)
		{
			bool result = false;
			foreach (string text in TargetList)
			{
				if (ObjectOnMousePosition.tag == text)
				{
					result = true;
				}
			}
			return result;
		}

		public static bool IsAimingOnNonShootableObject(GameObject ObjectOnMousePosition, string[] FriendList)
		{
			bool result = false;
			foreach (string text in FriendList)
			{
				if (ObjectOnMousePosition.tag == text)
				{
					result = true;
				}
			}
			return result;
		}

		public void MoveTowardsCenter(Image[] crosshairs, List<Vector3> crosshairStartPositions, float precision)
		{
			for (int i = 0; i < crosshairs.Length; i++)
			{
				Vector3 vector = crosshairs[i].transform.position - crosshairs[i].transform.parent.position;
				crosshairs[i].transform.localPosition = crosshairStartPositions[i] + vector.normalized * precision;
			}
		}

		public void ResizeCrosshair(Image crosshair, float precision)
		{
			if (!(crosshair == null))
			{
				float num = CrosshairStartScale.x + precision * CrosshairSensibility;
				crosshair.transform.localScale = new Vector3(num, num, num);
			}
		}

		public void SetActiveCrosshair(bool enabled)
		{
			if (Crosshairs.Length < 2)
			{
				Crosshairs[0].enabled = enabled;
				return;
			}
			Image[] crosshairs = Crosshairs;
			for (int i = 0; i < crosshairs.Length; i++)
			{
				crosshairs[i].enabled = enabled;
				CrosshairCenterPoint.enabled = enabled;
			}
		}

		protected void HideCrosshairOnNoWeaponUsing()
		{
			if (HideOnNoWeaponUsing)
			{
				SetActiveCrosshair(((bool)player.HoldableItemInUseRightHand || (bool)player.HoldableItemInUseLeftHand) ? true : false);
			}
		}

		public void HideCrosshairOnAiming()
		{
			if (HideOnAiming && (!HideOnNoWeaponUsing || !(player.HoldableItemInUseRightHand == null)))
			{
				SetActiveCrosshair(!player.IsAiming);
			}
		}

		public List<Vector3> GetCrosshairPositions(Image[] crosshairs)
		{
			List<Vector3> list = new List<Vector3>();
			foreach (Image image in crosshairs)
			{
				list.Add(image.transform.localPosition);
			}
			return list;
		}

		public static float GetWeaponPrecisionValue(float Current, Weapon WeaponInUse, float Speed = 8f)
		{
			if (Instance == null)
			{
				Instance = Object.FindObjectOfType<Crosshair>();
				return 0f;
			}
			return Mathf.Lerp(Current, Instance.CrosshairSensibility * 100f * (WeaponInUse ? WeaponInUse.ShotErrorProbability : 0f), Speed * Time.deltaTime);
		}
	}
}
