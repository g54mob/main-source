using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace VRTK
{
	public class VRTK_ValveArcPointerRenderer : VRTK_BasePointerRenderer
	{
		[Header("Valve Arc Pointer Appearance Settings")]
		[Tooltip("The maximum length of the arc.")]
		public float maximumLength = 10f;

		[Tooltip("Number of arc line segments.")]
		public int tracerDensity = 20;

		[Tooltip("The size of the ground cursor.")]
		public float cursorRadius = 0.5f;

		[Header("Custom Appearance Settings")]
		[Tooltip("A custom game object to use as the appearance for the pointer cursor. If this is empty then a Cylinder primitive will be created and used.")]
		public GameObject customCursor;

		[Tooltip("A custom game object can be applied here to appear only if the location is valid.")]
		public GameObject validLocationObject;

		[Tooltip("A custom game object can be applied here to appear only if the location is invalid.")]
		public GameObject invalidLocationObject;

		[Tooltip("Material for arc line.")]
		public Material arcMaterial;

		[Header("Valve Arc properties")]
		public int segmentCount = 60;

		public float thickness = 0.01f;

		[Tooltip("The amount of time in seconds to predict the motion of the projectile.")]
		public float arcDuration = 3f;

		[Tooltip("The amount of time in seconds between each segment of the projectile.")]
		public float segmentBreak = 0.025f;

		[Tooltip("The speed at which the line segments of the arc move.")]
		public float arcSpeed = 0.2f;

		[Tooltip("Prevents teleporting on steep surfaces, walls and ceilings. Threshold value is dot product.")]
		public float badCollisionAngleThreshold = 0.2f;

		[NonSerialized]
		public bool justTurnedOn;

		private Coroutine DelayedTracerVisualization;

		public LayerMask rotationLayers;

		protected ValveTeleportArc arc;

		protected GameObject actualContainer;

		protected GameObject actualCursor;

		protected GameObject actualValidLocationObject;

		protected GameObject actualInvalidLocationObject;

		private void Start()
		{
			if ((bool)controllingPointer)
			{
				SetupListeners(on: true);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				controllingPointer.ActivationButtonPressed += OnActivationButtonPressed;
			}
			else
			{
				controllingPointer.ActivationButtonPressed -= OnActivationButtonPressed;
			}
		}

		private void OnActivationButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			currentColor = Color.black;
		}

		public override void UpdateRenderer()
		{
			if ((controllingPointer != null && controllingPointer.IsPointerActive()) || IsVisible())
			{
				arc.traceLayerMask = ~(int)customRaycast.layersToIgnore;
				arc.SetArcData(GetOrigin().position, base.transform.forward * maximumLength, gravity: true, pointerAtBadAngle: false);
				arc.segmentCount = segmentCount;
				arc.thickness = thickness;
				arc.arcDuration = arcDuration;
				arc.segmentBreak = segmentBreak;
				arc.arcSpeed = arcSpeed;
				arc.UpdateRenderer();
				RaycastHit hitInfo;
				bool num = arc.DrawArc(out hitInfo);
				bool flag = ((bool)hitInfo.collider && ((bool)hitInfo.collider.GetComponentInParent<VRTK_DestinationPoint>() || (bool)hitInfo.collider.GetComponent<InvalidTeleportLocationReaction>())) || Vector3.Dot(hitInfo.normal, Vector3.up) > badCollisionAngleThreshold;
				if (!num || !flag || ((bool)destinationHit.collider && destinationHit.collider != hitInfo.collider))
				{
					if (destinationHit.collider != null)
					{
						PointerExit(destinationHit);
					}
					destinationHit = default(RaycastHit);
				}
				if (num && flag)
				{
					PointerEnter(hitInfo);
					destinationHit = hitInfo;
				}
				SetPointerCursor();
				MakeRenderersVisible();
				MakeRenderersVisible();
			}
			base.UpdateRenderer();
		}

		public override GameObject[] GetPointerObjects()
		{
			return new GameObject[2] { actualContainer, actualCursor };
		}

		protected override void ToggleRenderer(bool pointerState, bool actualState)
		{
			TogglePointerCursor(pointerState, actualState);
			TogglePointerTracer(pointerState, actualState);
		}

		protected override void CreatePointerObjects()
		{
			actualContainer = new GameObject(VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "ValveArcPointerRenderer_Container"));
			actualContainer.transform.SetParent(base.transform);
			actualContainer.transform.localPosition = Vector3.zero;
			actualContainer.transform.localRotation = Quaternion.identity;
			actualContainer.transform.localScale = Vector3.one;
			VRTK_PlayerObject.SetPlayerObject(actualContainer, VRTK_PlayerObject.ObjectTypes.Pointer);
			actualContainer.SetActive(value: false);
			CreateTracer();
			CreateCursor();
			Toggle(pointerState: false, actualState: false);
			if (controllingPointer != null)
			{
				controllingPointer.ResetActivationTimer(forceZero: true);
				controllingPointer.ResetSelectionTimer(forceZero: true);
			}
		}

		protected override void DestroyPointerObjects()
		{
			if (actualCursor != null)
			{
				UnityEngine.Object.Destroy(actualCursor);
			}
			if (arc != null)
			{
				UnityEngine.Object.Destroy(arc);
			}
			if (actualContainer != null)
			{
				UnityEngine.Object.Destroy(actualContainer);
			}
		}

		protected override void CreatePointerOriginTransformFollow()
		{
		}

		protected override void UpdatePointerOriginTransformFollow()
		{
		}

		protected new Transform GetOrigin(bool smoothed = true)
		{
			return base.transform;
		}

		protected override void UpdateObjectInteractor()
		{
			base.UpdateObjectInteractor();
			if (objectInteractor != null && actualCursor != null && Vector3.Distance(objectInteractor.transform.position, actualCursor.transform.position) > 0f)
			{
				objectInteractor.transform.position = actualCursor.transform.position;
			}
		}

		protected override void ChangeMaterial(Color givenColor)
		{
			base.ChangeMaterial(givenColor);
			ChangeMaterialColor(actualCursor, givenColor);
			arc.SetColor(givenColor);
		}

		protected virtual void CreateTracer()
		{
			arc = actualContainer.gameObject.AddComponent<ValveTeleportArc>();
			arc.enabled = false;
			arc.queryTriggerInteraction = QueryTriggerInteraction.Collide;
			arc.material = arcMaterial;
		}

		protected virtual GameObject CreateCursorObject()
		{
			float y = 0.02f;
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			MeshRenderer component = obj.GetComponent<MeshRenderer>();
			obj.transform.localScale = new Vector3(cursorRadius, y, cursorRadius);
			component.shadowCastingMode = ShadowCastingMode.Off;
			component.receiveShadows = false;
			component.material = defaultMaterial;
			UnityEngine.Object.Destroy(obj.GetComponent<CapsuleCollider>());
			return obj;
		}

		protected virtual void CreateCursorLocations()
		{
			if (validLocationObject != null)
			{
				actualValidLocationObject = UnityEngine.Object.Instantiate(validLocationObject);
				actualValidLocationObject.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "ValveArcPointerRenderer_ValidLocation");
				actualValidLocationObject.transform.SetParent(actualCursor.transform);
				actualValidLocationObject.transform.localPosition = new Vector3(0f, 0.05f, 0f);
				actualValidLocationObject.layer = LayerMask.NameToLayer("Ignore Raycast");
				actualValidLocationObject.SetActive(value: false);
			}
			if (invalidLocationObject != null)
			{
				actualInvalidLocationObject = UnityEngine.Object.Instantiate(invalidLocationObject);
				actualInvalidLocationObject.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "ValveArcPointerRenderer_InvalidLocation");
				actualInvalidLocationObject.transform.SetParent(actualCursor.transform);
				actualInvalidLocationObject.transform.localPosition = new Vector3(0f, 0.05f, 0f);
				actualInvalidLocationObject.layer = LayerMask.NameToLayer("Ignore Raycast");
				actualInvalidLocationObject.SetActive(value: false);
			}
		}

		protected virtual void CreateCursor()
		{
			actualCursor = ((customCursor != null) ? UnityEngine.Object.Instantiate(customCursor) : CreateCursorObject());
			actualCursor.transform.SetParent(base.transform);
			CreateCursorLocations();
			actualCursor.name = VRTK_SharedMethods.GenerateVRTKObjectName(true, base.gameObject.name, "ValveArcPointerRenderer_Cursor");
			VRTK_PlayerObject.SetPlayerObject(actualCursor, VRTK_PlayerObject.ObjectTypes.Pointer);
			actualCursor.layer = LayerMask.NameToLayer("Ignore Raycast");
			actualCursor.SetActive(value: false);
		}

		protected virtual void TogglePointerCursor(bool pointerState, bool actualState)
		{
			ToggleElement(actualCursor, pointerState, actualState, cursorVisibility, ref cursorVisible);
		}

		protected virtual void TogglePointerTracer(bool pointerState, bool actualState)
		{
			if (justTurnedOn)
			{
				tracerVisible = (justTurnedOn = false);
				TryAbortTracerActivation();
				DelayedTracerVisualization = StartCoroutine(TryActivateTracer(pointerState, actualState));
			}
			else
			{
				tracerVisible = tracerVisibility == VisibilityStates.AlwaysOn || pointerState;
			}
			if (actualContainer != null)
			{
				actualContainer.SetActive(tracerVisible);
			}
		}

		public void TryAbortTracerActivation()
		{
			if (DelayedTracerVisualization != null)
			{
				StopCoroutine(DelayedTracerVisualization);
			}
		}

		private IEnumerator TryActivateTracer(bool pointerState, bool actualState)
		{
			yield return null;
			yield return WaitFor.EndOfFrame;
			TogglePointerTracer(pointerState, actualState);
		}

		protected virtual void SetPointerCursor()
		{
			if (controllingPointer != null && (bool)destinationHit.transform)
			{
				TogglePointerCursor(controllingPointer.IsPointerActive(), controllingPointer.IsPointerActive());
				actualCursor.transform.position = destinationHit.point;
				if ((destinationHit.transform.gameObject.layer | (int)rotationLayers) != 0)
				{
					actualCursor.transform.rotation = Quaternion.FromToRotation(Vector3.up, destinationHit.normal);
				}
				else
				{
					actualCursor.transform.rotation = Quaternion.identity;
				}
				ChangeColor(validCollisionColor);
				if (actualValidLocationObject != null)
				{
					actualValidLocationObject.SetActive(ValidDestination() && IsValidCollision());
				}
				if (actualInvalidLocationObject != null)
				{
					actualInvalidLocationObject.SetActive(!ValidDestination() || !IsValidCollision());
					actualInvalidLocationObject.transform.position = destinationHit.point;
				}
				base.UpdateDependencies(actualCursor.transform.position);
			}
			else
			{
				TogglePointerCursor(pointerState: false, actualState: false);
				ChangeColor(invalidCollisionColor);
			}
		}
	}
}
