using Lightbug.CharacterControllerPro.Core;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class DemoSceneManager : MonoBehaviour
	{
		[Header("Character")]
		[SerializeField]
		private CharacterActor characterActor;

		[Header("Scene references")]
		[SerializeField]
		private CharacterReferenceObject[] references;

		[Header("UI")]
		[SerializeField]
		private Canvas infoCanvas;

		[SerializeField]
		private bool hideAndConfineCursor = true;

		[Header("Graphics")]
		[SerializeField]
		private GameObject graphicsObject;

		[Header("Camera")]
		[SerializeField]
		private Camera3D camera;

		[FormerlySerializedAs("frameRateText")]
		[SerializeField]
		private Text targetFrameRateText;

		private Renderer[] graphicsRenderers;

		private Renderer[] capsuleRenderers;

		private NormalMovement normalMovement;

		private float GetRefreshRateValue()
		{
			return (float)Screen.currentResolution.refreshRateRatio.value;
		}

		private void Awake()
		{
			if (characterActor != null)
			{
				normalMovement = characterActor.GetComponentInChildren<NormalMovement>();
			}
			if (normalMovement != null && camera != null)
			{
				if (camera.cameraMode == Camera3D.CameraMode.FirstPerson)
				{
					normalMovement.lookingDirectionParameters.lookingDirectionMode = LookingDirectionParameters.LookingDirectionMode.ExternalReference;
				}
				else
				{
					normalMovement.lookingDirectionParameters.lookingDirectionMode = LookingDirectionParameters.LookingDirectionMode.Movement;
				}
			}
			if (graphicsObject != null)
			{
				graphicsRenderers = graphicsObject.GetComponentsInChildren<Renderer>(includeInactive: true);
			}
			Cursor.visible = !hideAndConfineCursor;
			Cursor.lockState = (hideAndConfineCursor ? CursorLockMode.Locked : CursorLockMode.None);
			if (!(targetFrameRateText != null))
			{
				return;
			}
			targetFrameRateText.fontSize = 15;
			targetFrameRateText.rectTransform.sizeDelta = new Vector2(300f, 40f);
			if (QualitySettings.vSyncCount == 1)
			{
				targetFrameRateText.text = "Target frame rate = " + GetRefreshRateValue() + " fps ( Full Vsync )";
			}
			else if (QualitySettings.vSyncCount == 2)
			{
				targetFrameRateText.text = "Target frame rate = " + GetRefreshRateValue() / 2f + " fps ( Half Vsync )";
			}
			else if (QualitySettings.vSyncCount == 0)
			{
				if (Application.targetFrameRate == -1)
				{
					targetFrameRateText.text = "Target frame rate = Unlimited";
				}
				else
				{
					targetFrameRateText.text = $"Target frame rate = {Application.targetFrameRate} fps";
				}
			}
		}

		private void Update()
		{
			for (int i = 0; i < references.Length && references[i] != null; i++)
			{
				if (Input.GetKeyDown((KeyCode)(49 + i)) || Input.GetKeyDown((KeyCode)(257 + i)))
				{
					GoTo(references[i]);
					break;
				}
			}
			if (Input.GetKeyDown(KeyCode.Tab) && infoCanvas != null)
			{
				infoCanvas.enabled = !infoCanvas.enabled;
			}
			if (!Input.GetKeyDown(KeyCode.V) || !(camera != null))
			{
				return;
			}
			camera.ToggleCameraMode();
			if (normalMovement != null)
			{
				if (camera.cameraMode == Camera3D.CameraMode.FirstPerson)
				{
					normalMovement.lookingDirectionParameters.lookingDirectionMode = LookingDirectionParameters.LookingDirectionMode.ExternalReference;
				}
				else
				{
					normalMovement.lookingDirectionParameters.lookingDirectionMode = LookingDirectionParameters.LookingDirectionMode.Movement;
				}
			}
		}

		private void HandleVisualObjects(bool showCapsule)
		{
			if (capsuleRenderers != null)
			{
				for (int i = 0; i < capsuleRenderers.Length; i++)
				{
					capsuleRenderers[i].enabled = showCapsule;
				}
			}
			if (graphicsRenderers == null)
			{
				return;
			}
			for (int j = 0; j < graphicsRenderers.Length; j++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)graphicsRenderers[j];
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.forceRenderingOff = showCapsule;
				}
				else
				{
					graphicsRenderers[j].enabled = !showCapsule;
				}
			}
		}

		private void GoTo(CharacterReferenceObject reference)
		{
			if (reference != null && !(characterActor == null))
			{
				characterActor.constraintUpDirection = reference.referenceTransform.up;
				characterActor.Teleport(reference.referenceTransform);
				characterActor.upDirectionReference = reference.verticalAlignmentReference;
				characterActor.upDirectionReferenceMode = VerticalAlignmentSettings.VerticalReferenceMode.Away;
			}
		}
	}
}
