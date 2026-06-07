using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Craft.Parts.Modifiers.Wing;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using UnityEngine;
using Vectrosity;

namespace Assets.Scripts.Design
{
	public class DesignerGizmosScript : MonoBehaviour
	{
		private class Gizmo
		{
			public Func<bool> Enabled { get; set; }

			public GameObject GameObject { get; set; }

			public List<VectorLine> Lines { get; private set; }

			public Material Material { get; set; }

			public Action<Gizmo, IEnumerable<PartData>> RecalculateAction { get; set; }

			public bool Valid { get; set; }

			public Gizmo()
			{
				Lines = new List<VectorLine>();
			}

			public void Destroy()
			{
				if (Material != null)
				{
					UnityEngine.Object.Destroy(Material);
					Material = null;
				}
				if (Lines != null)
				{
					VectorLine.Destroy(Lines);
					Lines.Clear();
				}
			}
		}

		private const byte DefaultAlpha = 105;

		private const float LineSize = 5f;

		private DesignerScript _designer;

		private List<Gizmo> _gizmos = new List<Gizmo>();

		[SerializeField]
		private GameObject _template;

		public bool CenterOfLiftGizmoEnabled { get; set; }

		public bool CenterOfMassGizmoEnabled { get; set; }

		public bool CenterOfThrustGizmoEnabled { get; set; }

		public float GizmoScale { get; set; } = 1f;

		public int ReferenceStage { get; private set; }

		private Assembly CraftAssembly => _designer.CraftScript.Data.Assembly;

		public void Initialize(DesignerScript designer)
		{
			_template.SetActive(value: false);
			_designer = designer;
			base.transform.position = Vector3.zero;
			ReferenceStage = -1;
			byte a = 105;
			CreateGizmo("CenterOfMass", new Color32(202, 45, 45, a), () => CenterOfMassGizmoEnabled, delegate(Gizmo g, IEnumerable<PartData> p)
			{
				RecalculateCenterOfMassGizmo(g, p);
			});
			CreateGizmo("CenterOfThrust", new Color32(byte.MaxValue, 249, 62, a), () => CenterOfThrustGizmoEnabled, delegate(Gizmo g, IEnumerable<PartData> p)
			{
				RecalculateCenterOfThrustGizmo(g, p);
			});
			CreateGizmo("CenterOfLift", new Color32(55, 140, byte.MaxValue, a), () => CenterOfLiftGizmoEnabled, delegate(Gizmo g, IEnumerable<PartData> p)
			{
				RecalculateCenterOfLiftGizmo(g, p);
			});
			_designer.CraftStructureChanged += RecalculateGizmos;
			_designer.CraftLoaded += RecalculateGizmos;
			_designer.PerformanceAnalysis.EnvironmentChanged += OnPerformanceAnalysis_EnvironmentChanged;
		}

		public void SetReferenceStage(int stage)
		{
			if (stage == ReferenceStage)
			{
				return;
			}
			int num = 0;
			foreach (PartData part in _designer.CraftScript.Data.Assembly.Parts)
			{
				if (part.Config.StageActivationType != StageActivationType.None)
				{
					num = Mathf.Max(num, part.ActivationStage);
				}
			}
			ReferenceStage = Mathf.Clamp(stage, -1, num);
			RecalculateGizmos();
		}

		protected virtual void OnDestroy()
		{
			if (_gizmos == null)
			{
				return;
			}
			foreach (Gizmo gizmo in _gizmos)
			{
				gizmo?.Destroy();
			}
			_gizmos.Clear();
		}

		protected virtual void Update()
		{
			bool flag = false;
			foreach (Gizmo gizmo in _gizmos)
			{
				bool flag2 = gizmo.Enabled();
				if (flag2 == gizmo.GameObject.activeSelf)
				{
					continue;
				}
				gizmo.GameObject.SetActive(flag2);
				foreach (VectorLine line in gizmo.Lines)
				{
					line.active = flag2;
				}
				if (flag2)
				{
					flag = true;
				}
			}
			if (flag)
			{
				RecalculateGizmos();
			}
		}

		private static void UpdateGizmoLines(Gizmo gizmo)
		{
			Vector3 position = gizmo.GameObject.transform.position;
			float num = 5f;
			byte a = 105;
			if (!gizmo.Valid)
			{
				a = 20;
				num *= 0.5f;
			}
			Vector3 vector = Vector3.up * num;
			gizmo.Lines[0].points3[0] = position + vector;
			gizmo.Lines[0].points3[1] = position - vector;
			vector = Vector3.right * num;
			gizmo.Lines[1].points3[0] = position + vector;
			gizmo.Lines[1].points3[1] = position - vector;
			vector = Vector3.forward * num;
			gizmo.Lines[2].points3[0] = position + vector;
			gizmo.Lines[2].points3[1] = position - vector;
			foreach (VectorLine line in gizmo.Lines)
			{
				line.color = new Color32(line.color.r, line.color.g, line.color.b, a);
			}
		}

		private void CreateGizmo(string name, Color color, Func<bool> enabled, Action<Gizmo, IEnumerable<PartData>> recalculateAction)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_template);
			gameObject.name = name;
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			gameObject.SetActive(value: false);
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			component.material.color = color;
			component.material.name = "Gizmo Material (" + name + ")";
			Gizmo gizmo = new Gizmo();
			gizmo.GameObject = gameObject;
			gizmo.Material = component.material;
			gizmo.RecalculateAction = recalculateAction;
			gizmo.Enabled = enabled;
			CreateGizmoLines(gizmo, color);
			_gizmos.Add(gizmo);
		}

		private void CreateGizmoLines(Gizmo gizmo, Color color)
		{
			float width = 2.5f;
			gizmo.Lines.Add(new VectorLine("Up", new Vector3[2]
			{
				Vector3.zero,
				Vector3.one
			}.ToList(), null, width));
			gizmo.Lines.Add(new VectorLine("Right", new Vector3[2]
			{
				Vector3.zero,
				Vector3.one
			}.ToList(), null, width));
			gizmo.Lines.Add(new VectorLine("Forward", new Vector3[2]
			{
				Vector3.zero,
				Vector3.one
			}.ToList(), null, width));
			foreach (VectorLine line in gizmo.Lines)
			{
				line.layer = gizmo.GameObject.transform.gameObject.layer;
				line.color = color;
				line.Draw3DAuto();
				line.active = false;
				line.rectTransform.SetParent(base.transform, worldPositionStays: true);
			}
		}

		private void OnPerformanceAnalysis_EnvironmentChanged(object sender, EventArgs e)
		{
			RecalculateGizmos();
		}

		private void RecalculateCenterOfLiftGizmo(Gizmo gizmo, IEnumerable<PartData> parts)
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			ICraftScript craftScript = _designer.CraftScript;
			bool flag = craftScript != null && craftScript.PrimaryCommandPod?.CraftConfiguration.Type == CrafConfigurationType.Plane;
			foreach (PartData part in parts)
			{
				WingScript modifier = part.PartScript.GetModifier<WingScript>();
				if ((object)modifier != null && modifier.Data?.WingPhysicsEnabled == true)
				{
					modifier.WingPhysicsScript.UpdateStaticAerodynamicCenter();
					Vector3 aerodynamicCenterWorldSpace = modifier.WingPhysicsScript.AerodynamicCenterWorldSpace;
					float num2 = (flag ? Mathf.Abs(Vector3.Dot(modifier.Up, Vector3.up)) : 1f);
					zero += aerodynamicCenterWorldSpace * modifier.Data.WingArea * num2;
					num += modifier.Data.WingArea * num2;
				}
			}
			if (num > 0f)
			{
				gizmo.Valid = true;
				gizmo.GameObject.transform.position = zero / num;
				return;
			}
			gizmo.Valid = false;
			gizmo.GameObject.transform.position = Vector3.zero;
			CenterOfLiftGizmoEnabled = false;
			Game.Instance.Designer.ShowMessage("The center of lift gizmo can't be enabled because there are no wings in the craft.");
		}

		private void RecalculateCenterOfMassGizmo(Gizmo gizmo, IEnumerable<PartData> parts)
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (PartData part in parts)
			{
				float mass = part.Mass;
				zero += part.PartScript.Transform.TransformPoint(part.Config.CenterOfMass) * mass;
				num += mass;
			}
			if (num > 0f)
			{
				gizmo.Valid = true;
				gizmo.GameObject.transform.position = zero / num;
			}
			else
			{
				gizmo.Valid = false;
				gizmo.GameObject.transform.position = Vector3.zero;
			}
		}

		private void RecalculateCenterOfThrustGizmo(Gizmo gizmo, IEnumerable<PartData> parts)
		{
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (PartData part in parts)
			{
				IPartScript partScript = part.PartScript;
				IReactionEngine modifierWithInterface = partScript.GetModifierWithInterface<IReactionEngine>();
				if (modifierWithInterface != null)
				{
					if (partScript.GetModifier<EvaScript>() == null && (ReferenceStage == -1 || part.ActivationStage <= ReferenceStage))
					{
						zero += partScript.Transform.position * modifierWithInterface.MaximumThrust;
						num += modifierWithInterface.MaximumThrust;
					}
					continue;
				}
				PropellerAssemblyScript modifier = partScript.GetModifier<PropellerAssemblyScript>();
				if (modifier != null)
				{
					zero += partScript.Transform.position * modifier.Thrust;
					num += modifier.Thrust;
				}
			}
			if (num > 0f)
			{
				gizmo.Valid = true;
				gizmo.GameObject.transform.position = zero / num;
				return;
			}
			CenterOfThrustGizmoEnabled = false;
			Game.Instance.Designer.ShowMessage("The center of thrust gizmo can't be enabled because there are no compatible parts in the craft.");
			gizmo.Valid = false;
			gizmo.GameObject.transform.position = Vector3.zero;
		}

		private void RecalculateGizmos()
		{
			List<PartData> list = new List<PartData>();
			if (ReferenceStage >= 0)
			{
				List<PartConnection> list2 = new List<PartConnection>();
				foreach (PartData part in _designer.CraftScript.Data.Assembly.Parts)
				{
					if (part.Config.StageActivationType != StageActivationType.None && part.Config.StageActivationType == StageActivationType.Detacher && part.ActivationStage <= ReferenceStage)
					{
						list2.AddRange(part.PartConnections);
					}
				}
				PartGraph partGraph = new PartGraph(_designer.CraftScript.RootPart.Data, list2);
				list.AddRange(partGraph.Parts);
			}
			else
			{
				foreach (PartData part2 in _designer.CraftScript.Data.Assembly.Parts)
				{
					if (!part2.PartScript.Disconnected)
					{
						list.Add(part2);
					}
				}
			}
			foreach (Gizmo gizmo in _gizmos)
			{
				if (gizmo.Enabled())
				{
					gizmo.RecalculateAction(gizmo, list);
					Vector3 localScale = Vector3.one * GizmoScale;
					Color32 color = gizmo.Material.color;
					color.a = 105;
					if (!gizmo.Valid)
					{
						localScale *= 0.5f;
						color.a = 20;
					}
					gizmo.Material.color = color;
					gizmo.GameObject.transform.localScale = localScale;
					UpdateGizmoLines(gizmo);
				}
			}
		}
	}
}
