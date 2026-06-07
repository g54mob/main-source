using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Solar
{
	public class SolarPanelArrayScript : PartModifierScript<SolarPanelArrayData>, IAnalyzePerformance, IFlightStart, IGameLoopItem, IFlightUpdate, IFlightFixedUpdate
	{
		private static Dictionary<string, List<Vector4>> _originalUVs = new Dictionary<string, List<Vector4>>();

		private List<SolarPanelHinge> _allHinges = new List<SolarPanelHinge>();

		private Transform _baseCollider;

		private IFuelSource _battery;

		private bool _designDisplay;

		private GameObject _designerCoverCollider;

		private Vector3 _extensionClosedPosition = new Vector3(0f, 0.0263f, 0f);

		private Vector3 _extensionOpenPosition = new Vector3(0f, 0.1f, 0f);

		private Transform _extensionPiston;

		private Vector3 _firstHingePosition = new Vector3(0f, 0.0368f, 0f);

		private int _generatedVerticalPanels = 1;

		private GameObject _hinge;

		private Transform _hingeHolder;

		private GameObject _hingeJuice;

		private Vector3 _hingeHolderClosedPosition = new Vector3(0.4143605f, 0.1397518f, 0f);

		private bool _initialized;

		private Transform _leftmostPanelEdge;

		private int _largestRow;

		private Vector3 _mainHingePosition = new Vector3(-0.733f, 0f, 0f);

		private List<SolarPanelHinge> _mainHinges = new List<SolarPanelHinge>();

		private Vector3 _mainPanelPosition = new Vector3(0.007f, 0f, 0f);

		private Transform _meshes;

		private GameObject _panel;

		private BoxCollider _panelCollider;

		private float _rechargeEfficiency;

		private float _rechargeRate;

		private Transform _rightmostPanelEdge;

		private LoopingAudioScript _rotationAudio;

		private Vector3 _sideHingeEulers = new Vector3(-180f, 90f, 180f);

		private Vector3 _sideHingePosition = new Vector3(-0.37f, -0.008f, -0.479f);

		private Vector3 _sidePanelEulers = new Vector3(0f, -90f, 180f);

		private Vector3 _sidePanelPosition = new Vector3(0.48f, 0f, -0.37f);

		private Transform _solarCoverBase;

		private Transform _solarCoverLeft;

		private Transform _solarCoverRight;

		private Transform _topOfPanels;

		public bool UsesMachNumber => false;

		private float ExtensionPistonTravelSpeed => Vector3.Distance(_extensionClosedPosition, _extensionOpenPosition) / 3f / (float)Mathf.Max(1, _generatedVerticalPanels / 3);

		private float HingeHolderTravelSpeed => _hingeHolderClosedPosition.x / 3f / (float)Mathf.Max(1, _generatedVerticalPanels / 3);

		public void DisplayPanels(bool display = true)
		{
			_designDisplay = display;
			UpdatePanelCount();
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			ApplyDrag();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			Setup();
			UpdateScale();
			GeneratePanels(base.Data.Rows + (base.Data.Juicy ? 1 : 0), base.Data.RowSize);
			if (base.Data.StartOpen)
			{
				base.Data.Part.Activated = true;
				base.Data.StartOpen = false;
				for (int i = 0; i < _allHinges.Count; i++)
				{
					_allHinges[i].ShouldBeOpen = true;
				}
			}
			else
			{
				base.Data.Part.Config.MaxTemperature *= 2f;
			}
			OpenToSavedPercentage();
			PartCollisionIgnoreUtility.ApplyPartCollisions(base.PartScript);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_rechargeRate = 0f;
			_rechargeEfficiency = 0f;
			if (base.Data.Open != base.Data.Part.Activated)
			{
				if (base.Data.Part.Activated)
				{
					base.Data.Part.Config.MaxTemperature /= 2f;
				}
				else
				{
					base.Data.Part.Config.MaxTemperature *= 2f;
				}
			}
			base.Data.Open = base.Data.Part.Activated;
			float num = (float)frame.DeltaTimeWorld;
			if (!base.Data.HideBase)
			{
				if (base.Data.Open)
				{
					_solarCoverLeft.localRotation = Quaternion.RotateTowards(_solarCoverLeft.localRotation, Quaternion.Euler(_solarCoverLeft.localEulerAngles.x, _solarCoverLeft.localEulerAngles.y, 0f), num * base.Data.DeploySpeed * 150f);
					_solarCoverRight.localRotation = Quaternion.RotateTowards(_solarCoverRight.localRotation, Quaternion.Euler(_solarCoverRight.localEulerAngles.x, _solarCoverRight.localEulerAngles.y, 0f), num * base.Data.DeploySpeed * 150f);
				}
				else if (_mainHinges.Count == 0 || _mainHinges[0].IsClosed)
				{
					_solarCoverLeft.localRotation = Quaternion.RotateTowards(_solarCoverLeft.localRotation, Quaternion.Euler(_solarCoverLeft.localEulerAngles.x, _solarCoverLeft.localEulerAngles.y, 180f), num * base.Data.DeploySpeed * 150f);
					_solarCoverRight.localRotation = Quaternion.RotateTowards(_solarCoverRight.localRotation, Quaternion.Euler(_solarCoverRight.localEulerAngles.x, _solarCoverRight.localEulerAngles.y, -180f), num * base.Data.DeploySpeed * 150f);
				}
			}
			if (_allHinges == null || !_initialized)
			{
				return;
			}
			if (_mainHinges.Count == 0)
			{
				_rotationAudio.UpdateLoopAudio(0f);
				return;
			}
			bool flag = Utilities.CompareQuaternions(_mainHinges[0].transform.localRotation, _mainHinges[0].GetOpenRotation(), 1E-05f);
			for (int i = 0; i < _mainHinges.Count; i++)
			{
				_mainHinges[i].ShouldBeOpen = base.Data.Open;
			}
			bool flag2 = false;
			bool flag3 = base.Data.Open || base.Data.Juicy || !_mainHinges[0].IsClosed;
			Vector3 localPosition = _topOfPanels.parent.localPosition;
			localPosition.y = 0.003f * (float)((_mainHinges.Count % 2 == 0) ? 1 : (-1));
			_topOfPanels.parent.localPosition = localPosition;
			List<SolarPanelHinge> obj = new List<SolarPanelHinge> { _mainHinges[0] };
			List<SolarPanelHinge> mainHinges = _mainHinges;
			obj.Add(mainHinges[mainHinges.Count - 1]);
			List<SolarPanelHinge> list = obj;
			List<SolarPanelHinge> mainHinges2 = _mainHinges;
			mainHinges2[mainHinges2.Count - 1].RendererEnabled = true;
			List<SolarPanelHinge> mainHinges3 = _mainHinges;
			if (mainHinges3[mainHinges3.Count - 1].SideHinges.Count > 0)
			{
				List<SolarPanelHinge> mainHinges4 = _mainHinges;
				SolarPanelHinge solarPanelHinge = mainHinges4[mainHinges4.Count - 1].SideHinges[0];
				while (solarPanelHinge != null)
				{
					if (!solarPanelHinge.RendererEnabled)
					{
						solarPanelHinge.RendererEnabled = true;
					}
					list.Add(solarPanelHinge);
					solarPanelHinge = ((solarPanelHinge.SideHinges.Count > 0) ? solarPanelHinge.SideHinges[0] : null);
				}
				List<SolarPanelHinge> mainHinges5 = _mainHinges;
				object obj2;
				if (mainHinges5[mainHinges5.Count - 1].SideHinges.Count <= 1)
				{
					obj2 = null;
				}
				else
				{
					List<SolarPanelHinge> mainHinges6 = _mainHinges;
					obj2 = mainHinges6[mainHinges6.Count - 1].SideHinges[1];
				}
				solarPanelHinge = (SolarPanelHinge)obj2;
				while (solarPanelHinge != null)
				{
					if (!solarPanelHinge.RendererEnabled)
					{
						solarPanelHinge.RendererEnabled = true;
					}
					list.Add(solarPanelHinge);
					solarPanelHinge = ((solarPanelHinge.SideHinges.Count > 0) ? solarPanelHinge.SideHinges[0] : null);
				}
			}
			if (!flag || Utilities.CompareQuaternions(_extensionPiston.localRotation, Quaternion.identity) || !_mainHinges[_largestRow].AreSidesFullyClosed())
			{
				for (int j = 0; j < _allHinges.Count; j++)
				{
					if (!list.Contains(_allHinges[j]) && _allHinges[j].RendererEnabled != flag3)
					{
						_allHinges[j].RendererEnabled = flag3;
					}
					_allHinges[j].ArrayUpdate(num * base.Data.DeploySpeed);
					if (_allHinges[j].RotatedLastFrame)
					{
						flag2 = true;
					}
				}
			}
			if (flag2)
			{
				_rotationAudio.transform.localPosition = _panelCollider.center / base.Data.Scale;
				_rotationAudio.UpdateLoopAudio(0.3f);
			}
			else
			{
				_rotationAudio.UpdateLoopAudio(0f);
			}
			if (!base.Data.HideBase)
			{
				_hingeHolder.localPosition = Vector3.MoveTowards(_hingeHolder.localPosition, GetHingePosition((flag || base.Data.Open) ? 1 : 0), num * base.Data.DeploySpeed * HingeHolderTravelSpeed);
			}
			_extensionPiston.localPosition = Vector3.MoveTowards(_extensionPiston.localPosition, ((flag || base.Data.Open) && !base.Data.Juicy) ? _extensionOpenPosition : _extensionClosedPosition, num * base.Data.DeploySpeed * ExtensionPistonTravelSpeed);
			if (flag && base.Data.Open)
			{
				ICraftFlightData flightData = base.PartScript.CraftScript.FlightData;
				Vector3 solarRadiationFrameDirection = flightData.SolarRadiationFrameDirection;
				if (base.Data.RotateSpeed > 0f)
				{
					Vector3 direction = _extensionPiston.InverseTransformDirection((base.Data.Invert ? 1 : (-1)) * solarRadiationFrameDirection);
					direction.y = 0f;
					Quaternion localRotation = _extensionPiston.localRotation;
					_extensionPiston.rotation = Quaternion.LookRotation(-_extensionPiston.TransformDirection(direction).normalized, _extensionPiston.up);
					_extensionPiston.Rotate(Vector3.up, 90.1f);
					Quaternion localRotation2 = _extensionPiston.localRotation;
					_extensionPiston.localRotation = Quaternion.RotateTowards(localRotation, localRotation2, num * 50f * base.Data.RotateSpeed);
					flag2 = flag2 || (base.Data.RowSize % 2 != 0 && !Utilities.CompareQuaternions(localRotation, localRotation2));
				}
				float num2 = (float)flightData.SolarRadiationIntensity;
				_rechargeRate = num2 * base.Data.Efficiency * CalculateSolarArea();
				if (_rechargeRate > 0f)
				{
					_rechargeEfficiency = Mathf.Max(0f, Vector3.Dot(_extensionPiston.right, (base.Data.Invert ? 1 : (-1)) * solarRadiationFrameDirection));
					_rechargeRate *= _rechargeEfficiency;
				}
				else
				{
					_rechargeEfficiency = 0f;
				}
				_battery?.AddFuel(_rechargeRate * num / 1000f);
			}
			else if (!Utilities.CompareQuaternions(_extensionPiston.localRotation, Quaternion.identity))
			{
				_extensionPiston.localRotation = Quaternion.RotateTowards(_extensionPiston.localRotation, Quaternion.identity, num * 50f * base.Data.RotateSpeed);
				flag2 = flag2 || base.Data.RowSize % 2 != 0;
			}
			if (base.Data.SideOpenPercentage != 1f && base.Data.MainOpenPercentage != 0f)
			{
				HandleColliders(flag);
			}
			Quaternion openRotation = _mainHinges[0].GetOpenRotation();
			Quaternion closedRotation = _mainHinges[0].GetClosedRotation();
			float num3 = Quaternion.Angle(_mainHinges[0].transform.localRotation, closedRotation);
			float num4 = Quaternion.Angle(closedRotation, openRotation);
			base.Data.MainOpenPercentage = (float)Math.Round(num3 / num4, 6);
			if (_mainHinges[_largestRow].SideHinges.Count > 0)
			{
				int num5 = 0;
				SolarPanelHinge solarPanelHinge2 = _mainHinges[_largestRow].SideHinges[0];
				while (solarPanelHinge2 != null && Utilities.CompareQuaternions(solarPanelHinge2.transform.localRotation, solarPanelHinge2.GetOpenRotation(), 1E-05f))
				{
					solarPanelHinge2 = ((solarPanelHinge2.SideHinges.Count > 0) ? solarPanelHinge2.SideHinges[0] : null);
					if (solarPanelHinge2 != null)
					{
						num5++;
					}
				}
				base.Data.OpeningSideDepth = num5;
				if (solarPanelHinge2 != null)
				{
					Quaternion openRotation2 = solarPanelHinge2.GetOpenRotation();
					Quaternion closedRotation2 = solarPanelHinge2.GetClosedRotation();
					float num6 = Quaternion.Angle(solarPanelHinge2.transform.localRotation, closedRotation2);
					float num7 = Quaternion.Angle(closedRotation2, openRotation2);
					base.Data.SideOpenPercentage = (float)Math.Round(num6 / num7, 6);
				}
				else
				{
					base.Data.SideOpenPercentage = 1f;
				}
			}
			if (flag2)
			{
				UpdateCenterOfMass();
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Recharge Rate", () => Units.GetPowerString(_rechargeRate)));
			model.Add(new TextModel("Pointing Efficiency", () => Units.GetPercentageString(_rechargeEfficiency)));
			model.Add(new TextModel("Panel Efficiency", () => Units.GetPercentageString(base.Data.Efficiency)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Panel Efficiency", () => Units.GetPercentageString(base.Data.Efficiency), null, "The efficiency of the solar panel."));
			groupModel.Add(new TextModel("Peak Power", () => Units.GetPowerString((float)((double)(base.Data.Efficiency * (float)base.Data.Rows * (float)base.Data.RowSize * base.Data.CalculateSinglePanelArea()) * MathUtils.SolarEnergyFlux(Game.Instance.Designer.PerformanceAnalysis.Star, Math.Pow(Game.Instance.Designer.PerformanceAnalysis.StarDistance, 2.0)))), null, "The peak power generated when facing the sun directly in the selected planet."));
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			base.OnSymmetry(mode, originalPart, created);
			if (!base.Data.InvertOnMirror)
			{
				return;
			}
			if (mode != SymmetryMode.Mirror)
			{
				base.Data.Invert = originalPart.GetModifier<SolarPanelArrayScript>().Data.Invert;
			}
			else if (created)
			{
				base.Data.Invert = !originalPart.GetModifier<SolarPanelArrayScript>().Data.Invert;
			}
			else if (Game.InDesignerScene)
			{
				IPartScript partScript = Symmetry.GetSymmetricPartScripts(base.PartScript).FirstOrDefault((IPartScript x) => x != base.PartScript);
				if (partScript != null)
				{
					base.Data.Invert = !partScript.GetModifier<SolarPanelArrayScript>().Data.Invert;
				}
			}
		}

		public void UpdatePanelCount()
		{
			GeneratePanels(base.Data.Rows + (base.Data.Juicy ? 1 : 0), base.Data.RowSize);
			_hingeHolder.localPosition = GetHingePosition(_designDisplay ? 1 : 0);
			_extensionPiston.localPosition = ((_designDisplay && !base.Data.Juicy) ? _extensionOpenPosition : _extensionClosedPosition);
			if (!base.Data.HideBase)
			{
				_solarCoverLeft.localEulerAngles = new Vector3(0f, 0f, (!_designDisplay) ? 180 : 0);
				_solarCoverRight.localEulerAngles = new Vector3(0f, 0f, (!_designDisplay) ? (-180) : 0);
			}
			for (int i = 0; i < _allHinges.Count; i++)
			{
				_allHinges[i].SnapRotation(_designDisplay ? 1f : 0f);
			}
			HandleColliders();
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 1f * base.Data.Scale;
			}
			_meshes.localScale = Vector3.one * base.Data.Scale;
			_meshes.localPosition = 0.17f * base.Data.Scale * Vector3.down;
			bool flag = !base.Data.HideBase;
			_solarCoverBase.gameObject.SetActive(flag);
			_solarCoverLeft.gameObject.SetActive(flag);
			_solarCoverRight.gameObject.SetActive(flag);
			UpdateTiling();
			if (flag)
			{
				_solarCoverBase.transform.localScale = new Vector3(1f, 1f, base.Data.Length);
				_solarCoverLeft.transform.localScale = new Vector3(1f, 1f, base.Data.Length);
				_solarCoverRight.transform.localScale = new Vector3(1f, 1f, base.Data.Length);
				_baseCollider.localScale = new Vector3(1f, 1f, base.Data.Length);
				_baseCollider.localPosition = new Vector3(0f, base.Data.Juicy ? 0f : (base.Data.Invert ? (-0.026f) : 0.026f), 0f);
				_designerCoverCollider.SetActive(value: true);
			}
			else
			{
				_baseCollider.localScale = new Vector3(0.045f, 0.225f, 0.06f);
				_baseCollider.localPosition = Vector3.Scale(_hingeHolderClosedPosition, new Vector3((!base.Data.Juicy) ? ((!((base.Data.Folds < 0f) ^ base.Data.Invert)) ? 1 : (-1)) : 0, 1f, 1f));
				_designerCoverCollider.SetActive(value: false);
			}
		}

		public void UpdateTiling()
		{
			Mesh sharedMesh = _panel.GetComponentInChildren<MeshFilter>().sharedMesh;
			string key = _panel.name;
			if (!_originalUVs.ContainsKey(key))
			{
				_originalUVs[key] = new List<Vector4>();
				sharedMesh.GetUVs(0, _originalUVs[key]);
			}
			List<Vector4> list = _originalUVs[key];
			Vector4[] array = list.ToArray();
			for (int i = 0; i < list.Count; i++)
			{
				Vector4 vector = array[i];
				vector.y *= base.Data.Length;
				array[i] = vector;
			}
			sharedMesh.SetUVs(0, array);
		}

		protected override void OnInitialized()
		{
			if (!Game.InFlightScene)
			{
				Setup();
				UpdateScale();
				if (base.Data.MainOpenPercentage > 0f || base.Data.HideBase)
				{
					DisplayPanels(display: false);
					OpenToSavedPercentage();
				}
			}
		}

		private void ApplyDrag()
		{
			float num = CalculateSolarArea() * 0.01f;
			if (num > 0f)
			{
				Vector3 position = base.transform.position;
				IBodyScript bodyScript = base.PartScript.BodyScript;
				bodyScript.AddFrameDrag(Drag.DragDirection.Forward, num, position);
				bodyScript.AddFrameDrag(Drag.DragDirection.Backward, num, position);
				bodyScript.AddFrameDrag(Drag.DragDirection.Upward, num, position);
				bodyScript.AddFrameDrag(Drag.DragDirection.Downward, num, position);
				bodyScript.AddFrameDrag(Drag.DragDirection.Leftward, num, position);
				bodyScript.AddFrameDrag(Drag.DragDirection.Rightward, num, position);
			}
		}

		private float CalculateSolarArea()
		{
			if (_mainHinges.Count == 0)
			{
				return 0f;
			}
			float num = (float)base.Data.Rows * base.Data.MainOpenPercentage;
			if (_mainHinges[_largestRow].SideHinges.Count > 0)
			{
				num += (base.Data.SideOpenPercentage + (float)base.Data.OpeningSideDepth) * 2f * (float)base.Data.Rows;
			}
			return num * base.Data.CalculateSinglePanelArea();
		}

		private void GeneratePanels(int rows, int rowSize)
		{
			MeshRenderer[] componentsInChildren;
			if (_extensionPiston.childCount > 1)
			{
				foreach (Transform item in _extensionPiston)
				{
					if (!(item.name == "Audio"))
					{
						componentsInChildren = item.GetComponentsInChildren<MeshRenderer>();
						foreach (MeshRenderer renderer in componentsInChildren)
						{
							base.PartScript.PartMaterialScript.RemoveRenderer(renderer);
						}
						UnityEngine.Object.Destroy(item.gameObject);
					}
				}
				_mainHinges = new List<SolarPanelHinge>();
				_allHinges = new List<SolarPanelHinge>();
			}
			if (rows < 1)
			{
				return;
			}
			Transform transform2 = new GameObject("PanelCollider").transform;
			transform2.gameObject.layer = 31;
			transform2.SetParent(_extensionPiston);
			transform2.SetLocalPositionAndRotation(Vector3.up * 0.035f, Quaternion.identity);
			_panelCollider = transform2.gameObject.AddComponent<BoxCollider>();
			_panelCollider.size = new Vector3(0.05f, 0.05f, 0.0865f);
			_panelCollider.center = Vector3.zero;
			SolarPanelHinge solarPanelHinge = (base.Data.Juicy ? UnityEngine.Object.Instantiate(_hinge, _extensionPiston).AddComponent<SolarPanelHinge>() : UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Craft/Parts/Prefabs/Solar/BaseHinge"), _extensionPiston).AddComponent<SolarPanelHinge>());
			solarPanelHinge.transform.localPosition = _firstHingePosition;
			solarPanelHinge.transform.localEulerAngles = (base.Data.Invert ? new Vector3(0f, 180f, 0f) : new Vector3(0f, 0f, 0f));
			solarPanelHinge.OpenRotation = 270f + base.Data.Folds * 0.5f;
			solarPanelHinge.ClosedRotation = ((base.Data.Juicy ? (base.Data.Folds > 0f) : (base.Data.Folds >= 0f)) ? 360 : 180);
			solarPanelHinge.DeploySpeed = 0.5f / (float)(Mathf.Max(3, rows) / 3);
			solarPanelHinge.IsMainHinge = true;
			solarPanelHinge.IsBaseHinge = true;
			GameObject gameObject;
			if (base.Data.Juicy)
			{
				solarPanelHinge.transform.GetChild(0).transform.localScale = new Vector3(0.5f, 0.5f, 1.35f * base.Data.Length);
				gameObject = UnityEngine.Object.Instantiate(_hingeJuice, solarPanelHinge.transform);
			}
			else
			{
				gameObject = InstantiatePanel(solarPanelHinge.transform);
			}
			gameObject.transform.SetAsFirstSibling();
			gameObject.transform.localPosition = new Vector3(-0.04011658f, -0.01425126f, 0.0001325607f);
			gameObject.transform.localEulerAngles = Vector3.zero;
			_mainHinges.Add(solarPanelHinge);
			_allHinges.Add(solarPanelHinge);
			GameObject gameObject2 = gameObject;
			Vector3 localScale = new Vector3(1f, 1f, base.Data.Length);
			for (int j = 1; j < rows; j++)
			{
				SolarPanelHinge solarPanelHinge2 = solarPanelHinge;
				solarPanelHinge = UnityEngine.Object.Instantiate(_hinge, gameObject2.transform).AddComponent<SolarPanelHinge>();
				solarPanelHinge.transform.localPosition = ((j == 1 && base.Data.Juicy) ? 0.5f : 1f) * _mainHingePosition;
				solarPanelHinge.transform.localEulerAngles = Vector3.zero;
				solarPanelHinge.DeploySpeed = 1f / (float)(Mathf.Max(3, rows) / 3);
				solarPanelHinge.IsMainHinge = true;
				solarPanelHinge.HasCover = !base.Data.HideBase;
				_mainHinges.Add(solarPanelHinge);
				_allHinges.Add(solarPanelHinge);
				_mainHinges[j - 1].MainHingeChild = solarPanelHinge;
				solarPanelHinge.OpenRotation = ((j % 2 == 0) ? base.Data.Folds : (0f - base.Data.Folds));
				solarPanelHinge.ClosedRotation = 179.999f * (float)(((j % 2 == 0) ^ base.Data.Juicy) ? 1 : (-1));
				solarPanelHinge.transform.parent = solarPanelHinge2.transform;
				if (j == 1 && base.Data.Juicy)
				{
					solarPanelHinge.transform.localPosition = Vector3.Scale(solarPanelHinge.transform.localPosition, new Vector3(1f, 0f, 1f));
					solarPanelHinge.transform.GetChild(0).transform.localScale = new Vector3(0.75f, 0.75f, 10.5f * base.Data.Length);
					gameObject2.transform.localPosition = new Vector3(0f, -0.001f, 0f);
					gameObject2.transform.localScale = new Vector3(0.51f, 0.7f, base.Data.Length);
				}
				else
				{
					gameObject2.transform.localScale = localScale;
				}
				gameObject2 = InstantiatePanel(solarPanelHinge.transform);
				gameObject2.transform.SetAsFirstSibling();
				gameObject2.transform.localPosition = _mainPanelPosition;
				gameObject2.transform.localEulerAngles = Vector3.zero;
			}
			gameObject2.transform.localScale = localScale;
			_generatedVerticalPanels = _mainHinges.Count;
			_topOfPanels = new GameObject("PanelTop").transform;
			_topOfPanels.SetParent(gameObject2.transform);
			_topOfPanels.SetLocalPositionAndRotation(new Vector3(-0.73f, 0f, 0f), Quaternion.identity);
			int num = (base.Data.Juicy ? (-1) : 0);
			int[] rowSizeOverride = base.Data.RowSizeOverride;
			int largestRow = 0;
			int num2 = 0;
			foreach (SolarPanelHinge mainHinge in _mainHinges)
			{
				int num3 = rowSize;
				if (num < 0)
				{
					num3 = 0;
				}
				else if (rowSizeOverride != null && rowSizeOverride.Length > num)
				{
					num3 = ((rowSizeOverride[num] < 0) ? num3 : rowSizeOverride[num]);
				}
				if (num3 > num2)
				{
					num2 = num3;
					largestRow = (base.Data.Juicy ? (num + 1) : num);
				}
				for (int k = 0; k < num3 - 1; k++)
				{
					SolarPanelHinge solarPanelHinge3 = mainHinge;
					bool flag = true;
					if (solarPanelHinge3.SideHinges.Count >= 2)
					{
						if (k % 2 != 0)
						{
							flag = !flag;
							solarPanelHinge3 = solarPanelHinge3.SideHinges[1];
						}
						while (solarPanelHinge3.SideHinges.Count > 0)
						{
							flag = !flag;
							solarPanelHinge3 = solarPanelHinge3.SideHinges[0];
						}
					}
					solarPanelHinge = UnityEngine.Object.Instantiate(_hinge, solarPanelHinge3.transform.GetChild(0)).AddComponent<SolarPanelHinge>();
					solarPanelHinge.transform.localPosition = new Vector3(_sideHingePosition.x, _sideHingePosition.y * (float)(((k + (flag ? 1 : 0)) % 2 == 0) ? 1 : (-1)), _sideHingePosition.z * (float)((k % 2 != 0) ? 1 : (-1)));
					solarPanelHinge.transform.localEulerAngles = _sideHingeEulers;
					_allHinges.Add(solarPanelHinge);
					solarPanelHinge3.SideHinges.Add(solarPanelHinge);
					solarPanelHinge.transform.parent = solarPanelHinge3.transform;
					solarPanelHinge.transform.localScale = Vector3.one;
					solarPanelHinge.OpenRotation = ((k < 2) ? 180 : 0);
					solarPanelHinge.ClosedRotation = ((k < 2) ? (-0.001f) : 179.999f) * (float)(flag ? 1 : (-1));
					gameObject2 = InstantiatePanel(solarPanelHinge.transform);
					gameObject2.transform.SetAsFirstSibling();
					gameObject2.transform.localPosition = new Vector3(_sidePanelPosition.x * (float)((k % 2 != 0) ? 1 : (-1)) * base.Data.Length, _sidePanelPosition.y, _sidePanelPosition.z);
					gameObject2.transform.localEulerAngles = _sidePanelEulers;
					gameObject2.transform.localScale = localScale;
				}
				num++;
			}
			_largestRow = largestRow;
			SolarPanelHinge solarPanelHinge4 = _mainHinges[base.Data.Juicy ? 1 : 0];
			SolarPanelHinge solarPanelHinge5 = _mainHinges[base.Data.Juicy ? 1 : 0];
			if (solarPanelHinge4.SideHinges.Count > 0)
			{
				solarPanelHinge4 = solarPanelHinge4.SideHinges[0];
				while (solarPanelHinge4.SideHinges.Count > 0)
				{
					solarPanelHinge4 = solarPanelHinge4.SideHinges[0];
				}
			}
			_rightmostPanelEdge = new GameObject("PanelRight").transform;
			_rightmostPanelEdge.SetParent(solarPanelHinge4.transform.GetChild(0));
			_rightmostPanelEdge.SetLocalPositionAndRotation(new Vector3(0f, 0f, 0.475f), Quaternion.identity);
			if (solarPanelHinge5.SideHinges.Count > 1)
			{
				solarPanelHinge5 = solarPanelHinge5.SideHinges[1];
				while (solarPanelHinge5.SideHinges.Count > 0)
				{
					solarPanelHinge5 = solarPanelHinge5.SideHinges[0];
				}
			}
			_leftmostPanelEdge = new GameObject("PanelLeft").transform;
			_leftmostPanelEdge.SetParent(solarPanelHinge5.transform.GetChild(0));
			_leftmostPanelEdge.SetLocalPositionAndRotation(new Vector3(0f, 0f, -0.475f), Quaternion.identity);
			Utilities.SetLayerRecursive(_meshes.gameObject, 31);
			componentsInChildren = _mainHinges[0].GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer2 in componentsInChildren)
			{
				base.PartScript.PartMaterialScript.AddRenderer(renderer2, true);
			}
			_mainHinges[0].ArrayInitialize();
			_initialized = true;
		}

		private Vector3 GetHingePosition(float openPercentage)
		{
			return new Vector3((base.Data.Juicy ? 0f : (((base.Data.Folds >= 0f) ^ base.Data.Invert) ? 1f : (-1f))) * (base.Data.HideBase ? _hingeHolderClosedPosition.x : Mathf.Lerp(_hingeHolderClosedPosition.x, 0f, openPercentage)), _hingeHolder.localPosition.y, _hingeHolder.localPosition.z);
		}

		private void HandleColliders()
		{
			if (_mainHinges.Count != 0 && !(_mainHinges[0] == null))
			{
				bool mainFullyOpen = Utilities.CompareFloats(_mainHinges[0].transform.localEulerAngles.z, _mainHinges[0].OpenRotation, 0.0001f);
				HandleColliders(mainFullyOpen);
			}
		}

		private void HandleColliders(bool mainFullyOpen)
		{
			Vector3 center = _panelCollider.center;
			Vector3 vector = _panelCollider.transform.InverseTransformPoint(_topOfPanels.position);
			float num = (base.Data.Juicy ? (1f - 0.5f / ((float)base.Data.Rows + 0.5f)) : 1f);
			Vector3 size = default(Vector3);
			size.y = Mathf.Abs(vector.y * num);
			Transform obj = _panelCollider.transform;
			List<SolarPanelHinge> mainHinges = _mainHinges;
			size.x = Mathf.Abs(obj.InverseTransformPoint(mainHinges[mainHinges.Count - 1].transform.position).x - vector.x);
			size.z = base.Data.Length * base.Data.Scale * ((_mainHinges[_largestRow].SideHinges.Count == 0) ? 0.95f : 0.9624013f);
			center.y = vector.y - 0.5f * size.y;
			center.x = (base.Data.Juicy ? (0.05f * size.x) : (0.5f * size.x)) * (((base.Data.Folds >= 0f) ^ base.Data.Invert) ? (-1.125f) : 1.125f);
			center.z = 0f;
			size.x = Math.Max(0.05f, size.x);
			if (mainFullyOpen && _mainHinges[_largestRow].SideHinges.Count > 0)
			{
				float z = _panelCollider.transform.InverseTransformPoint(_leftmostPanelEdge.position).z;
				float z2 = _panelCollider.transform.InverseTransformPoint(_rightmostPanelEdge.position).z;
				center.z = (z + z2) * 0.5f;
				size.z = Mathf.Max(size.z, Mathf.Abs(z2 - z));
			}
			_panelCollider.size = size;
			_panelCollider.center = center;
		}

		private GameObject InstantiatePanel(Transform parent)
		{
			UpdatePanelTemplate();
			GameObject obj = UnityEngine.Object.Instantiate(_panel, parent);
			obj.SetActive(value: true);
			return obj;
		}

		private void OpenToSavedPercentage()
		{
			foreach (SolarPanelHinge mainHinge in _mainHinges)
			{
				mainHinge.SnapRotation(base.Data.MainOpenPercentage);
				if (mainHinge.SideHinges.Count > 0)
				{
					int num = base.Data.OpeningSideDepth;
					SolarPanelHinge solarPanelHinge = mainHinge.SideHinges[0];
					while (num > 0 && solarPanelHinge != null)
					{
						solarPanelHinge.SnapRotation(1f);
						num--;
						solarPanelHinge = ((solarPanelHinge.SideHinges.Count > 0) ? solarPanelHinge.SideHinges[0] : null);
					}
					solarPanelHinge?.SnapRotation(base.Data.SideOpenPercentage);
				}
				if (mainHinge.SideHinges.Count > 1)
				{
					int num2 = base.Data.OpeningSideDepth;
					SolarPanelHinge solarPanelHinge2 = mainHinge.SideHinges[1];
					while (num2 > 0 && solarPanelHinge2 != null)
					{
						solarPanelHinge2.SnapRotation(1f);
						num2--;
						solarPanelHinge2 = ((solarPanelHinge2.SideHinges.Count > 0) ? solarPanelHinge2.SideHinges[0] : null);
					}
					solarPanelHinge2?.SnapRotation(base.Data.SideOpenPercentage);
				}
			}
			_hingeHolder.localPosition = GetHingePosition(base.Data.MainOpenPercentage);
			_extensionPiston.localPosition = Vector3.Lerp(_extensionClosedPosition, _extensionOpenPosition, base.Data.MainOpenPercentage);
			_solarCoverLeft.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(-180f, 0f, base.Data.MainOpenPercentage * (float)(Mathf.Max(3, _mainHinges.Count + 1) / 3) * 2.5f));
			_solarCoverRight.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(180f, 0f, base.Data.MainOpenPercentage * (float)(Mathf.Max(3, _mainHinges.Count + 1) / 3) * 2.5f));
			HandleColliders();
		}

		private void Setup()
		{
			_meshes = base.transform.Find("Meshes");
			_hingeHolder = _meshes.Find("HingeHolder");
			_extensionPiston = _hingeHolder.Find("ExtensionPiston");
			_rotationAudio = _extensionPiston.GetComponentInChildren<LoopingAudioScript>();
			_hinge = Resources.Load<GameObject>("Craft/Parts/Prefabs/Solar/HingeCenter");
			_hingeJuice = Resources.Load<GameObject>("Craft/Parts/Prefabs/Solar/HingeJuice");
			_solarCoverLeft = _meshes.Find("SolarCoverLeft");
			_solarCoverRight = _meshes.Find("SolarCoverRight");
			_solarCoverBase = _meshes.Find("SolarCaseBase");
			_baseCollider = _meshes.Find("BaseCollider");
			_designerCoverCollider = _meshes.Find("DesignerCoverCollider").gameObject;
			base.Data.Part.Styles[1].TextureStyle = base.Data.Part.Styles[2].TextureStyle;
			UpdatePanelTemplate();
		}

		private void UpdateCenterOfMass()
		{
			if (base.PartScript.BodyScript?.RigidBody != null)
			{
				float num = base.Data.CalculateTotalPanelVolume();
				float num2 = base.Data.CalculateBaseVolume();
				Vector3 vector = base.transform.InverseTransformPoint(_panelCollider.transform.TransformPoint(_panelCollider.center / base.Data.Scale)) * num;
				Vector3 vector2 = _meshes.localPosition * num2;
				Vector3 centerOfMass = (vector + vector2) / (num + num2);
				base.PartScript.BodyScript.CenterOfMass = centerOfMass;
				base.PartScript.CraftScript.SetMassChanged();
			}
		}

		private void UpdatePanelTemplate()
		{
			string id = base.PartScript.Data.Styles[1].Style.Id;
			if (_panel == null || _panel.name != id)
			{
				_panel = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Craft/Parts/Prefabs/Solar/" + id));
				_panel.name = id;
				_panel.transform.SetParent(base.transform, worldPositionStays: false);
				_panel.SetActive(value: false);
				MeshFilter componentInChildren = _panel.GetComponentInChildren<MeshFilter>();
				Mesh sharedMesh = UnityEngine.Object.Instantiate(componentInChildren.sharedMesh);
				componentInChildren.sharedMesh = sharedMesh;
			}
			UpdateTiling();
		}
	}
}
