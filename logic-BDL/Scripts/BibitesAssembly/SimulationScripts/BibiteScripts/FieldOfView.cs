using System;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class FieldOfView : MonoBehaviour
	{
		private static float _delay = 0.25f;

		private static WaitForSeconds delayWS = new WaitForSeconds(_delay);

		private Collider2D[] elementsInViewRadius;

		[NonSerialized]
		public BibiteBody[] seenBibites = new BibiteBody[128];

		[NonSerialized]
		public MatterPellet[] seenPlantPellets = new MatterPellet[128];

		[NonSerialized]
		public MatterPellet[] seenMeatPellets = new MatterPellet[128];

		[NonSerialized]
		public GameObjectWeight[] plantWeights = new GameObjectWeight[128];

		[NonSerialized]
		public GameObjectWeight[] meatWeights = new GameObjectWeight[128];

		[NonSerialized]
		public GameObjectWeight[] bibiteWeights = new GameObjectWeight[128];

		[NonSerialized]
		public Transform[] held = new Transform[10];

		[NonSerialized]
		public int nHeld;

		[NonSerialized]
		public bool hasHerd;

		[NonSerialized]
		private BibiteGenes tarGene;

		[NonSerialized]
		public bool needToSee;

		[NonSerialized]
		public float dist2Bibite = float.PositiveInfinity;

		[NonSerialized]
		public float angle2Target;

		[NonSerialized]
		public float targetR;

		[NonSerialized]
		public float targetG;

		[NonSerialized]
		public float targetB;

		[NonSerialized]
		public int nPlants;

		[NonSerialized]
		public float pelletConcentrationAngle;

		[NonSerialized]
		public float pelletConcentrationWeight;

		[NonSerialized]
		public float maxPlantWeight;

		[NonSerialized]
		public int nMeat;

		[NonSerialized]
		public float meatConcentrationAngle;

		[NonSerialized]
		public float meatConcentrationWeight;

		[NonSerialized]
		public float maxMeatWeight;

		[NonSerialized]
		public int nBibite;

		[NonSerialized]
		public float bibiteConcentrationAngle;

		[NonSerialized]
		public float bibiteConcentrationWeight;

		[NonSerialized]
		public float maxBibiteWeight;

		private Vector2 herdHeadingVector;

		[NonSerialized]
		public Vector2 centerOfHerd;

		[NonSerialized]
		public Vector2 herdSeparationVector;

		[NonSerialized]
		public float herdSumDirection;

		[NonSerialized]
		public float herdSeparationProjection;

		private MatterMaterial meat = MatterMaterialManager.Meat;

		private MatterMaterial plant = MatterMaterialManager.Plant;

		private BibiteMouth mouth;

		private Vector3 upvect;

		private Vector2 dir2Target;

		private float dist2Target;

		private GameObject target;

		public float viewRadius = 100f;

		public float viewAngle = 180f;

		public float herdSeparationDistance = 10f;

		public float separationWeight = 1f;

		public float cohesionWeight = 1f;

		public float alignmentWeight = 1f;

		private int nBibitesInRange;

		private int nPlantsInRange;

		private int nMeatsInRange;

		public float plantWeightSum;

		public float meatWeightSum;

		public float bibiteWeightSum;

		public int targetMask;

		public LayerMask layerMask;

		public int targetLayer;

		private int bibiteLayer;

		private int pelletLayer;

		public bool seenThisFrame;

		private int nInRange;

		private static readonly BoolSetting DisableHerding = ScenarioSettings.Instance.disableHerding;

		private static bool herdingEnabled = !DisableHerding.SubscribeTo<BoolSetting, bool>(UpdateDisableHerding);

		private static void UpdateDisableHerding(bool val)
		{
			herdingEnabled = !val;
		}

		public void StartSeeing(int targets)
		{
			targetMask = targets;
			bibiteLayer = LayerMask.NameToLayer("bibite");
			pelletLayer = LayerMask.NameToLayer("pellets");
			if ((targetMask & 6) > 0)
			{
				layerMask = (int)layerMask | (1 << pelletLayer);
			}
			if ((targetMask & 1) > 0)
			{
				layerMask = (int)layerMask | (1 << bibiteLayer);
			}
			needToSee = targets > 0;
			elementsInViewRadius = new Collider2D[128];
			BibiteBody component = GetComponent<BibiteBody>();
			if (component != null)
			{
				mouth = component.mouth;
			}
			herdSumDirection = 0f;
		}

		public void FindSeenEntities()
		{
			if (!needToSee)
			{
				return;
			}
			nBibitesInRange = (nPlantsInRange = (nMeatsInRange = 0));
			Transform transform = base.transform;
			float num = Mathf.Min(0.25f * viewRadius, 25f);
			float num2 = viewAngle / 2f * (MathF.PI / 180f);
			if (num2 < MathF.PI * 5f / 8f)
			{
				float num3 = Mathf.Min(0f, viewRadius * Mathf.Cos(num2));
				Vector2 size = new Vector2(2f * viewRadius * ((viewAngle > 180f) ? 1f : Mathf.Sin(num2)), viewRadius - num3) + 2f * num * Vector2.one;
				Vector2 point = transform.position + (viewRadius + num3) / 2f * transform.up;
				float angle = Vector2.SignedAngle(Vector2.up, base.transform.up);
				nInRange = Physics2D.OverlapBoxNonAlloc(point, size, angle, elementsInViewRadius, layerMask);
			}
			else
			{
				nInRange = Physics2D.OverlapCircleNonAlloc(base.transform.position, viewRadius + num, elementsInViewRadius, layerMask);
			}
			for (int i = 0; i < nInRange; i++)
			{
				target = elementsInViewRadius[i].gameObject;
				targetLayer = target.layer;
				if (targetLayer == pelletLayer)
				{
					MatterPellet component = target.GetComponent<MatterPellet>();
					if (component.material == plant && (targetMask & 2) > 0)
					{
						seenPlantPellets[nPlantsInRange++] = component;
					}
					else if (component.material == meat && (targetMask & 4) > 0)
					{
						seenMeatPellets[nMeatsInRange++] = component;
					}
				}
				else
				{
					if (targetLayer != bibiteLayer || !(target.transform.parent != base.transform))
					{
						continue;
					}
					bool flag = false;
					GameObject gameObject = target.transform.parent.gameObject;
					for (int j = 0; j < nBibitesInRange; j++)
					{
						if (flag)
						{
							break;
						}
						flag |= bibiteWeights[j].gameObject == gameObject;
					}
					if (!flag)
					{
						bibiteWeights[nBibitesInRange].gameObject = gameObject;
						seenBibites[nBibitesInRange++] = gameObject.GetComponent<BibiteBody>();
					}
				}
			}
		}

		public void ComputeSenses()
		{
			if (!needToSee)
			{
				return;
			}
			seenThisFrame = true;
			upvect = base.transform.up;
			dist2Bibite = float.PositiveInfinity;
			bibiteWeightSum = 0f;
			plantWeightSum = 0f;
			meatWeightSum = 0f;
			nPlants = 0;
			nMeat = 0;
			nBibite = 0;
			targetR = 0f;
			targetG = 0f;
			targetB = 0f;
			maxBibiteWeight = 0f;
			maxPlantWeight = 0f;
			maxMeatWeight = 0f;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			Vector2 zero3 = Vector2.zero;
			centerOfHerd = (herdSeparationVector = (herdHeadingVector = Vector2.zero));
			if (mouth != null)
			{
				nHeld = mouth.nHeld;
				for (int i = 0; i < nHeld; i++)
				{
					held[i] = mouth.links[i].attachedRigidbody.transform;
				}
			}
			for (int j = 0; j < nPlantsInRange; j++)
			{
				MatterPellet matterPellet = seenPlantPellets[j];
				if (!(matterPellet == null) && !(matterPellet.amount < 0.01f) && !PelletIsHeld(matterPellet.transform) && TargetIsInView(matterPellet.transform, matterPellet.radius))
				{
					float num = Mathf.Pow(1.05f - dist2Target / viewRadius, 2f) * matterPellet.sizeFactor * (1.05f - Mathf.Abs(angle2Target) / (viewAngle / 2f));
					plantWeights[nPlants].gameObject = matterPellet.gameObject;
					plantWeights[nPlants++].weight = num;
					maxPlantWeight = Mathf.Max(maxPlantWeight, num);
					zero2 += dir2Target * num;
					plantWeightSum += num;
				}
			}
			for (int k = 0; k < nMeatsInRange; k++)
			{
				MatterPellet matterPellet2 = seenMeatPellets[k];
				if (!(matterPellet2 == null) && !(matterPellet2.amount < 0.01f) && !PelletIsHeld(matterPellet2.transform) && TargetIsInView(matterPellet2.transform, matterPellet2.radius))
				{
					float num2 = Mathf.Pow(1.05f - dist2Target / viewRadius, 2f) * matterPellet2.sizeFactor * (1.05f - Mathf.Abs(angle2Target) / (viewAngle / 2f));
					meatWeights[nMeat].gameObject = matterPellet2.gameObject;
					meatWeights[nMeat++].weight = num2;
					maxMeatWeight = Mathf.Max(maxMeatWeight, num2);
					zero3 += dir2Target * num2;
					meatWeightSum += num2;
				}
			}
			for (int l = 0; l < nBibitesInRange; l++)
			{
				BibiteBody bibiteBody = seenBibites[l];
				if (bibiteBody == null || bibiteBody.dying || !TargetIsInView(bibiteBody.transform, bibiteBody.sideRadius))
				{
					continue;
				}
				float num3 = bibiteBody.maxHealth / 100f * Mathf.Pow(1.05f - dist2Target / viewRadius, 2f) * (1.05f - Mathf.Abs(angle2Target) / (viewAngle / 2f));
				bibiteWeights[nBibite].gameObject = bibiteBody.gameObject;
				bibiteWeights[nBibite++].weight = num3;
				maxBibiteWeight = Mathf.Max(maxBibiteWeight, num3);
				zero += dir2Target * num3;
				bibiteWeightSum += num3;
				herdHeadingVector += (Vector2)bibiteBody.transform.up;
				centerOfHerd += dir2Target;
				if (dist2Target < herdSeparationDistance)
				{
					herdSeparationVector += -dir2Target.normalized * (1f - dist2Target / herdSeparationDistance);
				}
				if (!(dist2Target > dist2Bibite))
				{
					tarGene = bibiteBody.gene;
					if (tarGene.IsReady)
					{
						targetR = tarGene.genes[5];
						targetG = tarGene.genes[6];
						targetB = tarGene.genes[7];
					}
				}
			}
			if (plantWeightSum > 0f)
			{
				zero2 /= plantWeightSum;
			}
			if (meatWeightSum > 0f)
			{
				zero3 /= meatWeightSum;
			}
			if (bibiteWeightSum > 0f)
			{
				zero /= bibiteWeightSum;
			}
			bibiteConcentrationAngle = 2f * Vector2.SignedAngle(upvect, zero) / viewAngle;
			bibiteConcentrationWeight = ((bibiteWeightSum > 0f) ? (1f - Mathf.Min(zero.magnitude / viewRadius, 1f)) : 0f);
			pelletConcentrationAngle = 2f * Vector2.SignedAngle(upvect, zero2) / viewAngle;
			pelletConcentrationWeight = ((plantWeightSum > 0f) ? (1f - Mathf.Min(zero2.magnitude / viewRadius, 1f)) : 0f);
			meatConcentrationAngle = 2f * Vector2.SignedAngle(upvect, zero3) / viewAngle;
			meatConcentrationWeight = ((meatWeightSum > 0f) ? (1f - Mathf.Min(zero3.magnitude / viewRadius, 1f)) : 0f);
			if (nBibite > 0)
			{
				hasHerd = true;
				Vector2 to = herdSeparationVector.normalized * separationWeight + centerOfHerd.normalized * cohesionWeight + herdHeadingVector * alignmentWeight;
				herdSumDirection = Vector2.SignedAngle(upvect, to);
				herdSeparationProjection = Mathf.Cos(MathF.PI / 180f * Vector2.Angle(upvect, herdSeparationVector));
			}
			else
			{
				hasHerd = false;
				herdSumDirection = 0f;
				herdSeparationProjection = 0f;
			}
		}

		private bool PelletIsHeld(Transform pellet)
		{
			bool flag = false;
			for (int i = 0; i < nHeld; i++)
			{
				flag = held[i] == pellet.transform;
				if (flag)
				{
					held[i] = held[nHeld - 1];
					nHeld--;
				}
			}
			return flag;
		}

		private bool TargetIsInView(Transform targetTransform, float objectRadius)
		{
			dir2Target = targetTransform.position - base.transform.position;
			dist2Target = dir2Target.magnitude;
			if (dist2Target - objectRadius > viewRadius)
			{
				return false;
			}
			angle2Target = Vector2.SignedAngle(upvect, dir2Target);
			if (Mathf.Abs(angle2Target) < viewAngle / 2f)
			{
				dist2Target = Mathf.Max(dist2Target - objectRadius, 0.001f);
				dir2Target = dir2Target.normalized * dist2Target;
				return true;
			}
			float num = 2f * dist2Target * Mathf.Cos(MathF.PI / 180f * (Mathf.Abs(angle2Target) - viewAngle / 2f));
			float num2 = dist2Target * dist2Target - objectRadius * objectRadius;
			float num3 = num * num - 4f * num2;
			if (num3 <= 0f)
			{
				return false;
			}
			dist2Target = Mathf.Max(0.001f, num / 2f - Mathf.Sqrt(num3) / 2f);
			if (dist2Target > viewRadius)
			{
				return false;
			}
			angle2Target = Mathf.Sign(angle2Target) * viewAngle / 2f;
			dir2Target = VectorExtend.Rotate(upvect, MathF.PI / 180f * angle2Target) * dist2Target;
			return true;
		}

		private void OnDrawGizmosSelected()
		{
			Vector2 vector = base.transform.up;
			Vector2 vector2 = base.transform.right;
			float num = viewRadius;
			float num2 = Mathf.Min(0.25f * num, 50f);
			float f = viewAngle / 2f * (MathF.PI / 180f);
			float num3 = Mathf.Min(0f, num * Mathf.Cos(f));
			Vector2 vector3 = new Vector2(2f * num * ((viewAngle > 180f) ? 1f : Mathf.Sin(f)), num - num3) + 2f * num2 * Vector2.one;
			Vector2 vector4 = (Vector2)base.transform.position + (num + num3) / 2f * vector;
			Vector2 vector5 = vector4 + (vector * vector3.y + vector2 * vector3.x) / 2f;
			Vector2 vector6 = vector4 + (vector * vector3.y - vector2 * vector3.x) / 2f;
			Vector2 vector7 = vector4 + (-vector * vector3.y - vector2 * vector3.x) / 2f;
			Vector2 vector8 = vector4 + (-vector * vector3.y + vector2 * vector3.x) / 2f;
			Gizmos.DrawLine(vector5, vector6);
			Gizmos.DrawLine(vector6, vector7);
			Gizmos.DrawLine(vector7, vector8);
			Gizmos.DrawLine(vector8, vector5);
		}

		private void OnDestroy()
		{
			seenBibites = null;
			seenPlantPellets = null;
			seenMeatPellets = null;
			elementsInViewRadius = null;
		}
	}
}
