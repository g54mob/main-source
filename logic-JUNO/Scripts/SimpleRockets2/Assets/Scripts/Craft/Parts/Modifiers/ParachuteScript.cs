using System;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ParachuteScript : PartModifierScript<ParachuteData>, IAnalyzePerformance, IFlightUpdate, IGameLoopItem, IFlightStart, IFlightFixedUpdate, IDesignerStart
	{
		private string _altCut;

		private string _altInflate;

		private string _altDeploy;

		private Collider _baseCollider;

		private float _baseColliderDefaultYScale;

		private Transform _baseScalar;

		private Transform _chute;

		private GameObject _chuteBaseMesh;

		private Rigidbody _chuteBody;

		private SphereCollider _chuteCollider;

		private GameObject _chuteMesh;

		private Transform _chutePackage;

		private GameObject _chutePackageMesh;

		private Transform _chuteParent;

		private bool _deployed;

		private float _deployTime;

		private float _dragForceMagnitude;

		private float _dragPercentage;

		private float _inflateTime;

		private SpringJoint _joint;

		private float _prevDragMagnitude;

		private AudioSource _sound;

		public bool UpdateDensity { get; set; }

		public bool UsesMachNumber => true;

		private float DesignerPerformanceScale { get; set; }

		public void DeployParachute()
		{
			if (_deployed || !(base.PartScript.CraftScript.SurfaceVelocity.magnitude < base.Data.MaxDeploymentSpeed))
			{
				return;
			}
			bool num;
			if (!(base.Data.ASLDeployment > 0f))
			{
				if (base.Data.ReferenceDensity < 0f)
				{
					goto IL_00a9;
				}
				num = base.PartScript.CraftScript.AtmosphereSample.AirDensity > base.Data.DeploymentDensity;
			}
			else
			{
				num = base.PartScript.CraftScript.FlightData.AltitudeAboveSeaLevel < (double)base.Data.ASLDeployment;
			}
			if (!num)
			{
				return;
			}
			goto IL_00a9;
			IL_00a9:
			_deployed = true;
			Vector3 localScale = _baseCollider.transform.localScale;
			localScale.y = _baseColliderDefaultYScale / 4.5f;
			_baseCollider.transform.localScale = localScale;
			if (_chuteCollider == null)
			{
				_chuteCollider = _chutePackage.gameObject.AddComponent<SphereCollider>();
				Physics.IgnoreCollision(_baseCollider, _chuteCollider);
				_chuteCollider.radius = 0.1f;
			}
			else
			{
				_chuteCollider.enabled = true;
			}
			if (_chuteBody == null)
			{
				_chuteBody = _chutePackage.gameObject.AddComponent<Rigidbody>();
				_chuteBody.mass = 0.1f * base.Data.CalculateChuteArea() * 0.01f;
				_chuteBody.angularDrag = 0f;
				_chuteBody.maxDepenetrationVelocity = 1f;
				_chuteBody.drag = 0f;
				_chuteBody.useGravity = false;
			}
			if (_joint == null)
			{
				_joint = _chutePackage.gameObject.AddComponent<SpringJoint>();
				_joint.minDistance = 0f;
				_joint.maxDistance = 5f * base.Data.CordLength * base.Data.Scale;
				_joint.spring = 10f;
				_joint.damper = 0.2f;
				_joint.connectedBody = base.PartScript.BodyScript.RigidBody;
				_joint.enableCollision = true;
			}
			_chuteBody.position = base.transform.position + Vector3.Scale(base.transform.up, base.Data.Part.Config.PartScale) * (_baseColliderDefaultYScale / 2.25f);
			_chuteBody.velocity = base.PartScript.BodyScript.RigidBody.velocity + 50f * base.transform.up;
			_deployTime = 0f;
			_inflateTime = 0f;
			_chute.localScale = new Vector3(0f, 0f, 0f);
			_chute.gameObject.SetActive(value: true);
			_sound.Play();
			PartCollisionIgnoreUtility.ApplyPartCollisions(base.PartScript);
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			Game.Instance.Designer.PerformanceAnalysis.EnvironmentChanged += OnPerformanceAnalysisEnvironmentChanged;
			base.Data.RefreshPartProperties();
			UpdateDesignerPerformance();
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			_prevDragMagnitude = _dragForceMagnitude;
			_dragForceMagnitude = 0f;
			if (!_deployed || !base.PartScript.Data.Activated || !(_joint != null))
			{
				return;
			}
			float num = 0f;
			float num2 = 0f;
			float airDensity = base.PartScript.CraftScript.AtmosphereSample.AirDensity;
			if (_deployTime < 1f || ((base.Data.ASLInflation > 0f) ? (base.PartScript.CraftScript.FlightData.AltitudeAboveSeaLevel > (double)base.Data.ASLInflation) : (airDensity < base.Data.InflationDensity)))
			{
				if (_deployTime > 0.1f)
				{
					_chutePackageMesh.SetActive(value: false);
				}
				_deployTime += 2f * frame.DeltaTime;
				num = Mathf.Lerp(0f, base.Data.ChuteRadiusDeflated * base.Data.ChuteRadius, Mathf.Clamp01(_deployTime));
				num2 = Mathf.Clamp01(_deployTime) * base.Data.CordLength;
				_chute.localScale = new Vector3(2f * num, 2f * num, num2);
				_chuteCollider.radius = 3.6f * num;
			}
			else if ((double)airDensity > 1E-06)
			{
				if (base.Data.CutDensity > 0f && ((base.Data.ASLCut > 0f) ? (base.PartScript.CraftScript.FlightData.AltitudeAboveSeaLevel < (double)base.Data.ASLCut) : (airDensity > base.Data.CutDensity)))
				{
					base.PartScript.Data.Activated = false;
					return;
				}
				num = Mathf.Max(0.01f, Mathf.Lerp(base.Data.ChuteRadiusDeflated * base.Data.ChuteRadius, base.Data.ChuteRadius, _inflateTime));
				_inflateTime += Mathf.Clamp(0.05f * _prevDragMagnitude / num - 0.5f, -0.5f, 0.5f) * frame.DeltaTime;
				_inflateTime = Mathf.Clamp01(_inflateTime);
				num2 = base.Data.CordLength;
				_chute.localScale = new Vector3(2f * num, 2f * num, num2);
				_chuteCollider.radius = 3.6f * num;
			}
			if ((double)airDensity <= 1E-06 || base.PartScript.Data.DragScale == 0f || num * num2 == 0f)
			{
				return;
			}
			_chuteBody.angularDrag = base.Data.Scale * num;
			_joint.minDistance = 4.9f * num2 * base.Data.Scale;
			Vector3 vector = _chutePackage.position - base.transform.position;
			float magnitude = vector.magnitude;
			Vector3 surfaceVelocity = base.PartScript.BodyScript.SurfaceVelocity;
			float magnitude2 = surfaceVelocity.magnitude;
			if (magnitude > 0f && magnitude2 > 0f)
			{
				_dragPercentage = Mathf.Clamp01(0f - Vector3.Dot(surfaceVelocity / magnitude2, vector / magnitude));
			}
			else
			{
				_dragPercentage = 0f;
			}
			surfaceVelocity = ((_deployTime < 1f) ? Vector3.zero : _chuteBody.velocity) + base.PartScript.CraftScript.ReferenceFrame.FrameSurfaceVelocity;
			float num3 = base.Data.Drag * num * base.Data.Scale * num * base.Data.Scale * 0.01f * surfaceVelocity.sqrMagnitude;
			float num4 = num3;
			IPartWaterPhysics waterPhysics = base.PartScript.WaterPhysics;
			num3 = num4 * ((waterPhysics != null && waterPhysics.UnderWaterAmount > 0f) ? 10f : airDensity);
			_dragForceMagnitude = num3 * _dragPercentage;
			Rigidbody rigidBody = base.PartScript.BodyScript.RigidBody;
			Vector3 normalized = surfaceVelocity.normalized;
			if (base.Data.ReferenceDensity >= 0f && _dragForceMagnitude > base.Data.Scale * 30000f * base.Data.SnapThresholdMultiplier && base.PartScript.CommandPod != null)
			{
				Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog(base.PartScript.Data.Name + " [ID " + base.PartScript.Data.Id + "] broke off because it went under too much stress: " + Units.GetForceString(_dragForceMagnitude), FlightLogEntryCategory.CraftDamage, isDynamic: false, base.PartScript);
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage(base.PartScript.Data.Name + " broke off because it went under too much stress.", devlog: true);
				base.PartScript.Data.Activated = false;
				return;
			}
			Vector3 vector2 = -normalized * _dragForceMagnitude;
			rigidBody.AddForce(vector2);
			Vector3 force;
			if (magnitude2 < 0.01f)
			{
				force = Vector3.ProjectOnPlane(_chuteBody.position - rigidBody.position, base.PartScript.CraftScript.GravityForce).normalized;
			}
			else
			{
				force = -normalized * num3;
				force -= 0.2f * surfaceVelocity;
				force += 0.01f * magnitude2 * Vector3.ProjectOnPlane(UnityEngine.Random.insideUnitSphere, vector2);
			}
			force *= 0.01f;
			force += base.PartScript.CraftScript.GravityForce * _chuteBody.mass;
			force *= 2f - _dragPercentage;
			_chuteBody.AddForce(force);
			_chute.rotation = Quaternion.LookRotation(vector.normalized, new Vector3(-1f, -0.5f, 0f).normalized);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (base.PartScript.Data.Activated && !_deployed)
			{
				DeployParachute();
			}
			else if (!base.PartScript.Data.Activated && _deployTime > 0f)
			{
				_deployTime = 0f;
				_inflateTime = 0f;
				UnityEngine.Object.Destroy(_joint);
				UnityEngine.Object.Destroy(_chuteBody);
				_chuteCollider.enabled = false;
				_chutePackage.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				_chute.gameObject.SetActive(value: false);
				Vector3 localScale = _baseCollider.transform.localScale;
				localScale.y = _baseColliderDefaultYScale;
				_baseCollider.transform.localScale = localScale;
			}
		}

		public override float GetEstimatedDragForce()
		{
			return _dragForceMagnitude;
		}

		public void LoadBaseMesh(string name)
		{
			if (_chuteBaseMesh != null)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(_chuteBaseMesh.GetComponent<MeshRenderer>());
				UnityEngine.Object.DestroyImmediate(_chuteBaseMesh);
			}
			_chuteBaseMesh = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/Parachutes/Parachute" + name)) as GameObject;
			_chuteBaseMesh.transform.SetParent(_baseScalar.Find("LegacyParent"), worldPositionStays: false);
			_chuteBaseMesh.transform.localPosition = ((name == "Base") ? Vector3.zero : new Vector3(0f, -0.12f, 0f));
			_chuteBaseMesh.transform.localScale = Vector3.one;
			_chuteBaseMesh.transform.localRotation = Quaternion.identity;
			_chuteBaseMesh.transform.localRotation *= ((name == "Base") ? Quaternion.identity : Quaternion.Euler(0f, 90f, 0f));
			_chuteBaseMesh.name = "ParachuteBase";
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(_chuteBaseMesh, 31);
			base.PartScript.PartMaterialScript.AddRenderer(_chuteBaseMesh.GetComponent<MeshRenderer>(), false, false);
			if (_chutePackageMesh != null)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(_chutePackageMesh.GetComponent<MeshRenderer>());
				UnityEngine.Object.DestroyImmediate(_chutePackageMesh);
			}
			_chutePackageMesh = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/Parachutes/ChutePackage" + name)) as GameObject;
			_chutePackageMesh.transform.SetParent(_chutePackage, worldPositionStays: false);
			_chutePackageMesh.transform.localPosition = ((name == "Base") ? new Vector3(0f, -0.06f, 0f) : new Vector3(0f, -0.45f, 0f));
			_chutePackageMesh.transform.localScale = Vector3.one;
			_chutePackageMesh.transform.localRotation = Quaternion.identity;
			_chutePackageMesh.transform.localRotation *= ((name == "Base") ? Quaternion.identity : Quaternion.Euler(0f, 90f, 0f));
			_chutePackageMesh.name = "ChutePackageMesh";
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(_chutePackageMesh, 31);
			base.PartScript.PartMaterialScript.AddRenderer(_chutePackageMesh.GetComponent<MeshRenderer>(), true, false);
		}

		public void LoadChuteMesh(string name)
		{
			if (_chuteParent == null)
			{
				_chuteParent = Utilities.FindFirstGameObjectMyselfOrChildren("ChuteMeshParent", base.gameObject).transform;
			}
			if (_chuteMesh != null)
			{
				base.PartScript.PartMaterialScript.RemoveRenderer(_chuteMesh.GetComponent<MeshRenderer>());
				UnityEngine.Object.DestroyImmediate(_chuteMesh);
			}
			_chuteMesh = UnityEngine.Object.Instantiate(Resources.Load("Craft/Parts/Prefabs/Parachutes/" + name)) as GameObject;
			_chuteMesh.transform.SetParent(_chuteParent, worldPositionStays: false);
			_chuteMesh.transform.localPosition = Vector3.zero;
			_chuteMesh.transform.localScale = Vector3.one;
			_chuteMesh.transform.localRotation = Quaternion.identity;
			_chuteMesh.name = name;
			base.PartScript.PartMaterialScript.AddRenderer(_chuteMesh.GetComponent<MeshRenderer>(), true, true);
		}

		public override void OnActivated()
		{
			base.OnActivated();
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			GroupModel groupModel = new GroupModel("Parachute info");
			model.AddGroup(groupModel);
			groupModel.Add(new TextModel("Deployment", () => _altDeploy));
			groupModel.Add(new TextModel("Inflation", () => _altInflate));
			groupModel.Add(new TextModel("AutoCut", () => _altCut));
			groupModel.Add(new TextModel("Max Speed", () => IsBottleneck(base.Data.MaxDeploymentSpeed, base.PartScript.CraftScript.SurfaceVelocity.magnitude) + Units.GetVelocityString(base.Data.MaxDeploymentSpeed)));
			groupModel.Add(new TextModel("Snap Threshold", () => Units.GetForceString(base.Data.Scale * 30000f * base.Data.SnapThresholdMultiplier)));
			groupModel.Add(new TextModel("State:", delegate
			{
				if (base.PartScript.Data.Activated)
				{
					if (_deployed)
					{
						if (!(_deployTime < 1f))
						{
							if (!(_inflateTime <= 0f))
							{
								if (!(_inflateTime < 1f))
								{
									return "Inflated";
								}
								return "Inflating " + (int)(_inflateTime * 100f) + "%";
							}
							return "Deployed";
						}
						return "Deploying " + (int)(_deployTime * 100f) + "%";
					}
					return "Armed";
				}
				return _deployed ? "Cut" : "Packed";
			}));
			TextButtonModel item = new TextButtonModel("Repack", delegate
			{
				if (_deployed)
				{
					RepackChute();
				}
			});
			groupModel.Add(item);
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Drag at Deployment", () => Units.GetForceString(base.Data.DeploymentDensity * base.Data.ChuteRadiusDeflated * base.Data.ChuteRadiusDeflated * DesignerPerformanceScale), null, "How hard the chute would push going at the selected Mach at deployment."));
			groupModel.Add(new TextModel("Drag Pre Inflation", () => Units.GetForceString(base.Data.InflationDensity * base.Data.ChuteRadiusDeflated * base.Data.ChuteRadiusDeflated * DesignerPerformanceScale), null, "How hard the chute would push going at the selected Mach right before inflation."));
			groupModel.Add(new TextModel("Drag Post Inflation", () => Units.GetForceString(base.Data.InflationDensity * DesignerPerformanceScale), null, "How hard the chute would push going at the selected Mach right after inflation."));
			groupModel.Add(new TextModel("Drag at Sea Level", () => Units.GetForceString(base.Data.ReferenceDensity * DesignerPerformanceScale), null, "How hard the chute would push going at the selected Mach at sea level."));
			groupModel.Add(new TextModel("Snapping Force", () => Units.GetForceString(base.Data.Scale * 30000f * base.Data.SnapThresholdMultiplier), null, "At what force the parachute will snap."));
		}

		public override void OnPhysicsChanged(bool enabled)
		{
			if (_chuteBody != null)
			{
				_chuteBody.isKinematic = !enabled;
				if (enabled)
				{
					_chuteBody.velocity = base.PartScript.BodyScript.RigidBody.velocity;
				}
			}
		}

		public void RebuildChute()
		{
			IPartStyle style = base.PartScript.Data.Styles[1].Style;
			IPartStyle style2 = base.PartScript.Data.Styles[0].Style;
			LoadBaseMesh(style2.Id);
			LoadChuteMesh(style.Id);
			UpdateScale();
			if (Game.InDesignerScene)
			{
				UpdateDesignerPerformance();
			}
		}

		public override void RecalculateFrameState(Vector3 positionDelta, Vector3 velocityDelta)
		{
			if (_chuteBody != null)
			{
				_chuteBody.position += positionDelta;
				_chuteBody.velocity += velocityDelta;
			}
		}

		public void RepackChute()
		{
			_deployed = false;
			base.PartScript.Data.Activated = false;
			_chutePackageMesh.SetActive(value: true);
		}

		public void ShowParachute(bool active)
		{
			_chute.gameObject.SetActive(active);
			_chutePackage.gameObject.SetActive(!active);
			if (active)
			{
				UpdateScale();
			}
			else
			{
				_chute.localScale = new Vector3(0f, 0f, 0f);
			}
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 1f * base.Data.Scale;
			}
			_chute.localScale = new Vector3(2f * base.Data.ChuteRadius, 2f * base.Data.ChuteRadius, base.Data.CordLength);
			_chuteParent.localScale = new Vector3(1f, 2f * base.Data.ChuteHeight / base.Data.CordLength, 1f);
			_baseScalar.localScale = new Vector3(base.Data.Scale, base.Data.Scale, base.Data.Scale);
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			OnPlayerChangedSoi(null, base.PartScript.CraftScript.CraftNode.Parent);
		}

		protected virtual void OnDestroy()
		{
			if (Game.InDesignerScene)
			{
				Game.Instance.Designer.PerformanceAnalysis.EnvironmentChanged -= OnPerformanceAnalysisEnvironmentChanged;
			}
		}

		protected override void OnInitialized()
		{
			_baseCollider = GetComponentInChildren<Collider>();
			_baseColliderDefaultYScale = _baseCollider.transform.localScale.y;
			_baseScalar = Utilities.FindFirstGameObjectMyselfOrChildren("Scalar", base.gameObject).transform;
			_chutePackage = Utilities.FindFirstGameObjectMyselfOrChildren("ChutePackage", base.gameObject).transform;
			_chuteBaseMesh = Utilities.FindFirstGameObjectMyselfOrChildren("ParachuteBase", base.gameObject);
			_chutePackageMesh = Utilities.FindFirstGameObjectMyselfOrChildren("ChutePackageMesh", base.gameObject);
			_chute = Utilities.FindFirstGameObjectMyselfOrChildren("Chute", base.gameObject).transform;
			_chute.gameObject.SetActive(value: false);
			_sound = GetComponent<AudioSource>();
			RebuildChute();
			if (Game.InFlightScene)
			{
				Game.Instance.FlightScene.PlayerChangedSoi += OnPlayerChangedSoi;
			}
		}

		private string IsBottleneck(float value, float threshold)
		{
			if (value > threshold)
			{
				return "<color=red>";
			}
			return string.Empty;
		}

		private void OnPerformanceAnalysisEnvironmentChanged(object sender, EventArgs e)
		{
			UpdateDesignerPerformance();
			if (UpdateDensity)
			{
				base.Data.RefreshPartProperties();
			}
		}

		private void OnPlayerChangedSoi(ICraftNode playerCraftNode, IPlanetNode newParent)
		{
			IPlanetAtmosphereData atmosphereData = newParent.PlanetData.AtmosphereData;
			double surfaceAirDensity = atmosphereData.SurfaceAirDensity;
			if (surfaceAirDensity == 0.0)
			{
				_altCut = "No Atmos";
				_altInflate = "No Atmos";
				_altDeploy = "No Atmos";
			}
			else if (base.Data.ASLCut >= 0f)
			{
				_altCut = Units.GetDistanceString(base.Data.ASLCut);
				_altInflate = Units.GetDistanceString(base.Data.ASLInflation);
				_altDeploy = Units.GetDistanceString(base.Data.ASLDeployment);
			}
			else
			{
				double scaleHeight = atmosphereData.ScaleHeight;
				float num = (float)PlanetAtmosphereData.CalculateAtmosphereHeight(scaleHeight, surfaceAirDensity, base.Data.CutDensity);
				_altCut = ((num < 0f) ? "Disabled" : Units.GetDistanceString(num));
				_altInflate = Units.GetDistanceString((float)PlanetAtmosphereData.CalculateAtmosphereHeight(scaleHeight, surfaceAirDensity, base.Data.InflationDensity));
				_altDeploy = Units.GetDistanceString((float)PlanetAtmosphereData.CalculateAtmosphereHeight(scaleHeight, surfaceAirDensity, base.Data.DeploymentDensity));
			}
		}

		private void UpdateDesignerPerformance()
		{
			DesignerPerformanceScale = base.Data.Drag * 0.01f * Mathf.Pow(base.Data.Scale * base.Data.ChuteRadius * Game.Instance.Designer.PerformanceAnalysis.MachNumber * Game.Instance.Designer.PerformanceAnalysis.AtmosphereSample.SpeedOfSound, 2f);
		}
	}
}
