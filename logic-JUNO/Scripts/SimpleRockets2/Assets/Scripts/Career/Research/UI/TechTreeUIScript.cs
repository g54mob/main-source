using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Menu.Tutorial;
using Assets.Scripts.State;
using DG.Tweening;
using ModApi;
using ModApi.Audio;
using ModApi.Flight.UI;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Career.Research.UI
{
	public class TechTreeUIScript : MonoBehaviour
	{
		public const float ZoomClose = 4f;

		public const float ZoomFar = 30f;

		private AudioSource _audioSource;

		private Bounds _bounds;

		[SerializeField]
		private Camera _camera;

		private Vector3 _cameraStartRotation;

		[SerializeField]
		private Transform _cameraTarget;

		[SerializeField]
		private GameObject _detailsPrefab;

		private bool _dragging;

		private BlockScript _hoveredBlock;

		[SerializeField]
		private InputHandlerScript _inputHandler;

		private InputResponder _inputResponder = new InputResponder("TechTree");

		[SerializeField]
		private XmlLayout _layout;

		[SerializeField]
		private GameObject _linePrefab;

		private NodeDetailsScript _nodeDetails;

		[SerializeField]
		private GameObject _nodePrefab;

		private int _numResearchPoints;

		[SerializeField]
		private PartLoaderScript _partLoader;

		private TextMeshProUGUI _researchPointsText;

		private NodeScript _rootNode;

		[SerializeField]
		private float _scrollSensitivity = 0.1f;

		private NodeScript _selectedNode;

		public PartLoaderScript PartLoader => _partLoader;

		public TechTree TechTree { get; private set; }

		public void CreateDetailsForNode(NodeScript node)
		{
			if (_nodeDetails != null)
			{
				_nodeDetails.Close();
			}
			if (node != null)
			{
				GameObject gameObject = Object.Instantiate(_detailsPrefab);
				gameObject.transform.SetParent(base.transform);
				_nodeDetails = gameObject.GetComponent<NodeDetailsScript>();
				_nodeDetails.ShowDetails(node, this);
			}
		}

		public Transform CreateLine()
		{
			GameObject obj = Object.Instantiate(_linePrefab);
			obj.transform.SetParent(base.transform);
			return obj.transform;
		}

		public void OnCloseButtonClicked()
		{
			Close();
		}

		public bool OnDrag(PointerEventData eventData)
		{
			_dragging = true;
			Vector3 right = _camera.transform.right;
			right.y = 0f;
			right.Normalize();
			Vector3 forward = _camera.transform.forward;
			forward.y = 0f;
			forward.Normalize();
			float num = Mathf.InverseLerp(4f, 30f, _camera.orthographicSize);
			Vector2 vector = eventData.delta / Screen.height * Mathf.Lerp(10f, 50f, num);
			Vector3 movement = (0f - vector.x) * right + (0f - vector.y) * forward;
			PositionCamera(movement, num);
			if (_selectedNode == null)
			{
				_cameraTarget.localRotation = Quaternion.Euler(TiltAndPan());
			}
			return true;
		}

		public bool OnEndDrag(PointerEventData eventData)
		{
			_dragging = false;
			return true;
		}

		public void OnNodeResearched(NodeScript node)
		{
			SetSelectedNode(null);
			node.MarkAsResearched(1f);
			node.TechNode.Researched = true;
			TechTree.RefreshItemStatus();
			TechTree.ResearchPoints -= node.TechNode.Cost;
			UpdateResearchPoints();
			UpdateColorsRecursive(_rootNode);
			_camera.DOShakePosition(0.6f, 0.5f, 40, 60f);
			PlaySound(AudioLibrary.Flight.DockConnect, force: true);
			Game.Instance.GameState.Save();
			if (Game.Instance.Analytics.Enabled)
			{
				FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
				Dictionary<string, object> eventData = new Dictionary<string, object>
				{
					{
						"TechTreeNodeId",
						node.TechNode.Id
					},
					{
						"TechNodesUnlocked",
						TechTree.AllNodes.Count((TechNode x) => x.Researched)
					},
					{ "TechPoints", TechTree.ResearchPoints },
					{
						"CareerPlaytimeInMinutes",
						(int)((flightStateData?.TotalFlightTimeInRealtimeSeconds ?? 0.0) / 60.0)
					}
				};
				Game.Instance.Analytics.LogEvent("TechTreeNodeUnlock", eventData);
			}
		}

		public bool OnPointerClick(PointerEventData eventData)
		{
			if (!_dragging)
			{
				BlockScript blockAtScreenPosition = GetBlockAtScreenPosition(eventData.position);
				if (blockAtScreenPosition != null)
				{
					blockAtScreenPosition.OnClicked();
				}
				else
				{
					PlaySound(AudioLibrary.ButtonClicked);
					SetSelectedNode(null);
				}
			}
			return true;
		}

		public void PlaySound(AudioFile audioFile, bool force = false)
		{
			if (audioFile != null && (_audioSource == null || !_audioSource.isPlaying || force))
			{
				_audioSource = Game.Instance.AudioPlayer.PlaySound(audioFile);
			}
		}

		public void SetSelectedNode(NodeScript node)
		{
			if (_selectedNode != null)
			{
				_selectedNode.Selected = false;
			}
			if (_selectedNode != node)
			{
				_selectedNode = node;
				if (_selectedNode != null)
				{
					_selectedNode.Selected = true;
					MoveCameraToNode(_selectedNode);
					TiltCamera(tilt: true);
				}
				else
				{
					TiltCamera(tilt: false);
				}
			}
			else
			{
				_selectedNode = null;
				TiltCamera(tilt: false);
			}
			CreateDetailsForNode(_selectedNode);
		}

		protected virtual void Awake()
		{
		}

		protected void Start()
		{
			TechTree = Game.Instance.GameState.Career?.TechTree;
			if (TechTree == null || !Game.IsCareer)
			{
				Debug.LogError("The tech tree is not available. Check that the current game state is not set to Sandbox mode.");
				Game.Instance.SceneManager.LoadMenu();
			}
			_cameraStartRotation = _cameraTarget.localRotation.eulerAngles;
			_inputHandler.AddInputResponder(_inputResponder);
			_inputResponder.OnDrag = OnDrag;
			_inputResponder.OnEndDrag = OnEndDrag;
			_inputResponder.OnScroll = OnScroll;
			_inputResponder.OnPointerClick = OnPointerClick;
			_inputResponder.OnPointerDown = OnPointerDown;
			_inputResponder.OnPinch = OnPinch;
			_layout.XmlLayoutController.EventTarget = this;
			_layout.RebuildLayout(forceEvenIfXmlUnchanged: true);
			TechTree = Game.Instance.GameState.Career.TechTree;
			_researchPointsText = _layout.GetElementById<TextMeshProUGUI>("research-points");
			_numResearchPoints = 0;
			UpdateResearchPoints();
			_rootNode = CreateNode(TechTree.RootNode);
			_rootNode.RefreshLayout(new Vector3(0f, 0.1f, 0f), createLines: false);
			_rootNode.gameObject.SetActive(value: false);
			_bounds = new Bounds(_rootNode.transform.position + new Vector3(_rootNode.TotalWidth / 2f, 0f, 0f), new Vector3(_rootNode.TotalWidth + 5f, 0f, _rootNode.TotalHeight + 15f));
			TiltCamera(tilt: false);
			PartLoader.LoadDesignerPart("Drood", new Vector3(0f, -100f, 0f), 0.01f, delegate(GameObject g)
			{
				Object.Destroy(g);
			});
			MenuTutorialPanelScript.ShowTutorial();
			UpdateColorsRecursive(_rootNode);
		}

		protected virtual void Update()
		{
			if (!Device.IsMobileBuild)
			{
				BlockScript blockAtScreenPosition = GetBlockAtScreenPosition(UnityEngine.Input.mousePosition);
				SetHighlightedBlock(blockAtScreenPosition);
			}
			if (CareerState.IsDebugMode)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadPlus))
				{
					Game.Instance.GameState.Career.ReceiveTechPoints(100);
					UpdateResearchPoints();
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					SetSelectedNode(null);
					UnlockAllNodes(_rootNode);
					TechTree.RefreshItemStatus();
				}
			}
			if (Game.Instance.UserInterface.ActiveDialog == null && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
		}

		private static void UnlockAllNodes(NodeScript node)
		{
			node.MarkAsResearched();
			node.TechNode.Researched = true;
			foreach (NodeScript child in node.Children)
			{
				UnlockAllNodes(child);
			}
		}

		private static void UpdateColorsRecursive(NodeScript node)
		{
			node.UpdateColor();
			foreach (NodeScript child in node.Children)
			{
				UpdateColorsRecursive(child);
			}
		}

		private void Close()
		{
			Game.Instance.GameState.Save();
			Game.Instance.SceneManager.LoadPreviousScene();
		}

		private NodeScript CreateNode(TechNode techNode)
		{
			GameObject obj = Object.Instantiate(_nodePrefab);
			obj.transform.SetParent(base.transform);
			NodeScript component = obj.GetComponent<NodeScript>();
			component.Initialize(techNode);
			foreach (TechNode item in techNode.Children.Reverse())
			{
				CreateNode(item).SetParent(component);
			}
			return component;
		}

		private BlockScript GetBlockAtScreenPosition(Vector2 screenPosition)
		{
			Ray ray = _camera.ScreenPointToRay(screenPosition);
			BlockScript result = null;
			if (Physics.Raycast(ray, out var hitInfo, 10000f, 1))
			{
				result = hitInfo.collider.GetComponentInParent<BlockScript>();
			}
			return result;
		}

		private void MoveCameraToNode(NodeScript node)
		{
			Vector3 forward = _camera.transform.forward;
			forward.y = 0f;
			int num = node.TechNode.Items.Where((TechItemValue x) => x.Visible).Count();
			_cameraTarget.DOMove(node.transform.position + new Vector3(0.5f * node.Width, 0f, 0f) + num * forward.normalized, 0.25f);
			_camera.DOOrthoSize(4f + 0.5f * (float)num, 0.25f);
		}

		private bool OnPinch(PinchEventData eventData)
		{
			if (eventData.Distance > 0f)
			{
				OnZoomed((eventData.Distance - eventData.DistanceDelta) / eventData.Distance, eventData.Midpoint);
			}
			return true;
		}

		private bool OnPointerDown(PointerEventData eventData)
		{
			if (Device.IsMobileBuild)
			{
				BlockScript blockAtScreenPosition = GetBlockAtScreenPosition(UnityEngine.Input.mousePosition);
				SetHighlightedBlock(blockAtScreenPosition);
			}
			return true;
		}

		private bool OnScroll(PointerEventData eventData)
		{
			OnZoomed(1f - eventData.scrollDelta.y * _scrollSensitivity, eventData.position);
			return true;
		}

		private void OnZoomed(float amount, Vector2 center)
		{
			_camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize * amount, 4f, 30f);
			float num = Mathf.InverseLerp(4f, 30f, _camera.orthographicSize);
			if (num > 0.01f)
			{
				PositionCamera((1f - amount) * Mathf.Lerp(20f, 80f, num) * new Vector3(center.x / (float)_camera.pixelWidth - 0.5f, 0f, center.y / (float)_camera.pixelHeight - 0.5f), num);
				if (num > 0.35f && _selectedNode != null)
				{
					SetSelectedNode(null);
				}
			}
			if (_selectedNode == null)
			{
				TiltCamera(tilt: false);
			}
		}

		private void PositionCamera(Vector3 movement, float range)
		{
			Vector3 position = _cameraTarget.transform.position + movement;
			Vector3 vector = Vector3.Lerp(_bounds.min, _bounds.center, range);
			Vector3 vector2 = Vector3.Lerp(_bounds.max, _bounds.center, range);
			position.x = Mathf.Clamp(position.x, vector.x, vector2.x);
			position.y = Mathf.Clamp(position.y, vector.y, vector2.y);
			position.z = Mathf.Clamp(position.z, vector.z, vector2.z);
			_cameraTarget.transform.position = position;
		}

		private void SetHighlightedBlock(BlockScript block)
		{
			if (_hoveredBlock != block)
			{
				if (_hoveredBlock != null)
				{
					_hoveredBlock.OnHover(hover: false);
				}
				_hoveredBlock = block;
				if (_hoveredBlock != null)
				{
					_hoveredBlock.OnHover(hover: true);
				}
			}
		}

		private Vector3 TiltAndPan()
		{
			float t = Mathf.InverseLerp(_bounds.min.x, _bounds.max.x, _cameraTarget.localPosition.x);
			float t2 = Mathf.InverseLerp(_bounds.min.z, _bounds.max.z, _cameraTarget.localPosition.z);
			return new Vector3(Mathf.Lerp(_cameraStartRotation.x, 80f, t2), _cameraStartRotation.y * Mathf.Lerp(1f, -1f, t), _cameraStartRotation.z);
		}

		private void TiltCamera(bool tilt)
		{
			Vector3 endValue = (tilt ? new Vector3(35f, 25f, 0f) : TiltAndPan());
			_cameraTarget.DORotate(endValue, 0.25f);
		}

		private void UpdateResearchPoints()
		{
			DOTween.To(() => _numResearchPoints, delegate(int x)
			{
				_numResearchPoints = x;
				_researchPointsText.text = _numResearchPoints.ToString();
			}, TechTree.ResearchPoints, 1f).SetEase(Ease.OutSine);
		}
	}
}
