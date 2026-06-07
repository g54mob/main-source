using System;
using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using PropertiesScripts;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteMouth : BibiteSpatialOrgan, ISaveable
	{
		[SerializeField]
		private GameObject mainBody;

		[SerializeField]
		private BibiteStomach stomach;

		private Rigidbody2D rb;

		[NonSerialized]
		public UnityEvent<GameObject> OnEnterMouth = new UnityEvent<GameObject>();

		[NonSerialized]
		public UnityEvent<GameObject> OnSwallow = new UnityEvent<GameObject>();

		[NonSerialized]
		public UnityEvent<GameObject, float> OnAttack = new UnityEvent<GameObject, float>();

		[NonSerialized]
		public UnityEvent<GameObject> OnExitMouth = new UnityEvent<GameObject>();

		public readonly FixedJoint2D[] links = new FixedJoint2D[10];

		public int nHeld;

		private readonly GameObject[] objectsInMouth = new GameObject[10];

		private int nInMouth;

		private FixedJoint2D tempLink;

		private Rigidbody2D targetRigidbody2D;

		private BibiteBody otherBody;

		private MatterPellet targetPellet;

		private GrabbableObject grabbableObject;

		private BoxCollider2D mouthTrigger;

		private float diet;

		private bool isStarted;

		private bool attackedLastFrame;

		private bool attackedThisFrame;

		private int totalMurders;

		private float murderedArea;

		private float jawAreaPortion;

		private float throatWidth;

		private float throatRadius;

		[NonSerialized]
		public bool instaKill;

		[NonSerialized]
		private float desireToSwallow;

		[NonSerialized]
		private float desireToGrab;

		[NonSerialized]
		private float desireToAttack;

		[NonSerialized]
		private float mouthOpening;

		[NonSerialized]
		private float biteOpening;

		[NonSerialized]
		public float jawArea;

		[NonSerialized]
		private float jawMass;

		[NonSerialized]
		public float jawStrength;

		[NonSerialized]
		private float biteStrength;

		[NonSerialized]
		private bool canSwallow;

		[NonSerialized]
		public float bitePeriod;

		[NonSerialized]
		public float biteProgress;

		[NonSerialized]
		public int bibitesBitten;

		[NonSerialized]
		public float totalDamageDealt;

		private float damageDealt;

		private const float ThrowingDesireThreshold = -0.25f;

		private const float BitingDesireThreshold = 0.15f;

		private const float VomitingDesireThreshold = -0.15f;

		private static readonly FloatSetting BitingDamages = ScenarioSettings.Instance.bitingDamageFactor;

		private static readonly FloatSetting BitingPressure = ScenarioSettings.Instance.bitingPressure;

		private static readonly FloatSetting ThrowingForce = ScenarioSettings.Instance.throwingForceFactor;

		private static readonly FloatSetting BitingThrowForce = ScenarioSettings.Instance.bitingThrowForceFactor;

		private static readonly FloatSetting JawSpeed = ScenarioSettings.Instance.bitePeriodFactor;

		private static readonly FloatSetting JawMusclesSizingPower = ScenarioSettings.Instance.jawMusclesSizingPower;

		private static readonly FloatSetting BibiteMassDensity = ScenarioSettings.Instance.bibiteMassDensity;

		private static readonly FloatSetting MinPelletSize = ScenarioSettings.Instance.minPelletSize;

		private static float bitingDamageFactor = BitingDamages.SubscribeTo<FloatSetting, float>(UpdateBitingDamages);

		private static float bitingPressure = BitingPressure.SubscribeTo<FloatSetting, float>(UpdateBitingPressure);

		private static float throwingForceFactor = ThrowingForce.SubscribeTo<FloatSetting, float>(UpdateThrowingForce);

		private static float bitingThrowForceFactor = BitingThrowForce.SubscribeTo<FloatSetting, float>(UpdateBitingThrowForce);

		private static float jawMusclesSizingPower = JawMusclesSizingPower.SubscribeTo<FloatSetting, float>(UpdateJawMusclesSizingPower);

		private static float bitePeriodFactor = JawSpeed.SubscribeTo<FloatSetting, float>(UpdateJawSpeed);

		private static float bibiteMassDensity = BibiteMassDensity.SubscribeTo<FloatSetting, float>(UpdateBibiteMassDensity);

		private static float minPelletSize = MinPelletSize.SubscribeTo<FloatSetting, float>(UpdateMinPelletSize);

		protected override BibiteGenes.Genes apportionmentGene => BibiteGenes.Genes.ThroatWAG;

		protected BibiteGenes.Genes apportionmentMuscleGene => BibiteGenes.Genes.MouthMusclesWAG;

		public override float mass => 0f;

		public float grabOutput => brain.Output(NEATBrain.Outputs.Grab);

		public float attackOutput => brain.Output(NEATBrain.Outputs.Want2Attack);

		public float swallowOutput => brain.Output(NEATBrain.Outputs.Want2Eat);

		public bool ableToSwallow
		{
			get
			{
				if (swallowOutput > 0.15f)
				{
					return biteProgress >= bitePeriod;
				}
				return false;
			}
		}

		public bool readyToAttack
		{
			get
			{
				if (attackOutput > 0.15f)
				{
					return biteProgress >= bitePeriod;
				}
				return false;
			}
		}

		public float swallowWidth
		{
			get
			{
				if (!(swallowOutput > 0.15f))
				{
					return 0f;
				}
				return desireToSwallow * throatWidth;
			}
		}

		public float swallowAmount => MathF.PI * Mathf.Pow(swallowWidth / 2f, 2f);

		public float maxAmountNoBiteNeeded => MathF.PI * Mathf.Pow(swallowWidth / 4f, 2f);

		public float biteForce
		{
			get
			{
				if (!(desireToAttack > 0.15f))
				{
					return 0f;
				}
				return jawStrength * desireToAttack;
			}
		}

		public float biteWidth
		{
			get
			{
				if (!(desireToAttack > 0.15f))
				{
					return 0f;
				}
				return desireToAttack * throatWidth;
			}
		}

		private static void UpdateBitingDamages(float val)
		{
			bitingDamageFactor = val;
		}

		private static void UpdateBitingPressure(float val)
		{
			bitingPressure = val;
		}

		private static void UpdateThrowingForce(float val)
		{
			throwingForceFactor = val;
		}

		private static void UpdateBitingThrowForce(float val)
		{
			bitingThrowForceFactor = val;
		}

		private static void UpdateJawMusclesSizingPower(float val)
		{
			jawMusclesSizingPower = val;
		}

		private static void UpdateJawSpeed(float val)
		{
			bitePeriodFactor = val;
		}

		private static void UpdateBibiteMassDensity(float val)
		{
			bibiteMassDensity = val;
		}

		private static void UpdateMinPelletSize(float val)
		{
			minPelletSize = val;
		}

		public override void InitOrgan(BibiteBody bibite)
		{
			base.InitOrgan(bibite);
			FixedJoint2D[] components = mainBody.GetComponents<FixedJoint2D>();
			foreach (FixedJoint2D fixedJoint2D in components)
			{
				if (nHeld < 10)
				{
					links[nHeld++] = fixedJoint2D;
				}
			}
			mouthTrigger = GetComponent<BoxCollider2D>();
			diet = genes.Gene(BibiteGenes.Genes.Diet);
			float y = ((diet < 0.5f) ? (7f - 8f * diet) : 3f);
			mouthTrigger.size = new Vector2(2.72f, y);
			rb = mainBody.GetComponent<Rigidbody2D>();
			jawAreaPortion = genes.jawAreaPortion;
			JawSpeed.Subscribe(UpdateBitePeriod);
			JawMusclesSizingPower.Subscribe(UpdateJawStrength);
			BitingPressure.Subscribe(UpdateJawStrength);
			BibiteMassDensity.Subscribe(UpdateMouthSizeParameters);
			UpdateMouthSizeParameters();
			isStarted = true;
		}

		protected override void OnGrowth(float val = 1f)
		{
			base.OnGrowth(val);
			UpdateMouthSizeParameters();
		}

		private void UpdateMouthSizeParameters()
		{
			jawArea = body.baseBodyArea * jawAreaPortion;
			jawMass = jawArea * bibiteMassDensity / 2f;
			throatWidth = Mathf.Sqrt(area);
			UpdateJawStrength();
			UpdateBitePeriod();
		}

		private void UpdateBitePeriod()
		{
			bitePeriod = ((jawArea > 0f) ? (Mathf.Sqrt(throatWidth * jawMass / jawStrength) * 70f * bitePeriodFactor) : 1000000f);
		}

		private void UpdateJawStrength()
		{
			jawStrength = bitingPressure * Mathf.Pow(jawArea * metabolicRate, jawMusclesSizingPower / 2f);
		}

		public override void UpdateOrgan()
		{
			if (!isStarted || Time.timeScale <= 0f)
			{
				return;
			}
			attackedLastFrame = attackedThisFrame;
			attackedThisFrame = false;
			if (biteProgress < bitePeriod)
			{
				biteProgress += Time.fixedDeltaTime;
			}
			if (swallowOutput < -0.15f && biteProgress >= bitePeriod)
			{
				Vomit();
				biteProgress -= bitePeriod;
			}
			else
			{
				if (nInMouth == 0 && nHeld == 0)
				{
					return;
				}
				Vector3 pos = base.transform.position;
				Array.Sort(objectsInMouth, delegate(GameObject o0, GameObject o1)
				{
					float x = ((o0 != null) ? (o0.transform.position - pos).magnitude : 100000f);
					float y = ((o1 != null) ? (o1.transform.position - pos).magnitude : 100000f);
					return Comparer<float>.Default.Compare(x, y);
				});
				nInMouth = 0;
				for (int num = 0; num < objectsInMouth.Length; num++)
				{
					if (!(objectsInMouth[num] != null))
					{
						nInMouth = num;
						break;
					}
				}
				if (nInMouth == 0)
				{
					return;
				}
				desireToAttack = attackOutput;
				desireToGrab = grabOutput;
				desireToSwallow = swallowOutput;
				canSwallow = ableToSwallow;
				mouthOpening = swallowWidth;
				biteOpening = biteWidth;
				biteStrength = biteForce;
				if (desireToGrab >= 0.15f)
				{
					for (int num2 = 0; num2 < nInMouth; num2++)
					{
						GameObject gameObject = objectsInMouth[num2];
						grabbableObject = gameObject.GetComponent<GrabbableObject>();
						if (grabbableObject == null && gameObject.transform.parent != null)
						{
							grabbableObject = gameObject.transform.parent.gameObject.GetComponent<GrabbableObject>();
						}
						if (grabbableObject != null)
						{
							TryGrabTarget(grabbableObject);
						}
					}
					float num3 = jawStrength * Mathf.Max(diet, 0.1f) * desireToGrab / (float)nHeld;
					for (int num4 = 0; num4 < nHeld; num4++)
					{
						FixedJoint2D obj = links[num4];
						obj.breakForce = num3;
						obj.breakTorque = num3;
					}
				}
				else if (nHeld > 0 && desireToGrab <= -0.15f)
				{
					ReleaseAndMaybeThrowAllHeldObjects(throwObjects: true);
				}
				for (int num5 = 0; num5 < nInMouth; num5++)
				{
					GameObject gameObject2 = objectsInMouth[num5];
					if (!canSwallow || desireToSwallow <= (CheckIfTargetIsGrabbed(gameObject2.gameObject) ? desireToGrab : 0.15f))
					{
						if (desireToAttack > 0.15f)
						{
							MaybeAttack(gameObject2.gameObject, attackedLastFrame);
						}
					}
					else if (!TrySwallowTarget(gameObject2.gameObject) && desireToAttack > 0.15f)
					{
						MaybeAttack(gameObject2.gameObject, attackedLastFrame);
					}
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (isStarted && nInMouth < 10)
			{
				GameObject gameObject = other.gameObject;
				objectsInMouth[nInMouth++] = gameObject;
				OnEnterMouth.Invoke(gameObject);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (!isStarted)
			{
				return;
			}
			for (int i = 0; i < nInMouth; i++)
			{
				if (!(objectsInMouth[i] != other.gameObject))
				{
					objectsInMouth[i] = objectsInMouth[nInMouth - 1];
					objectsInMouth[nInMouth - 1] = null;
					ReleaseTargetIfHeld(other.GetComponent<Rigidbody2D>());
					OnExitMouth.Invoke(other.gameObject);
					nInMouth--;
				}
			}
		}

		public void OnLinkBroke(Joint2D brokenJoint)
		{
			if (!(brokenJoint is FixedJoint2D fixedJoint2D))
			{
				return;
			}
			for (int i = 0; i < nHeld; i++)
			{
				if (!(links[i] != fixedJoint2D))
				{
					links[i].connectedBody.GetComponent<GrabbableObject>().Release(this);
					links[i].connectedBody = null;
					UnityEngine.Object.Destroy(links[i]);
					links[i] = links[nHeld - 1];
					nHeld--;
					break;
				}
			}
		}

		private void OnDestroy()
		{
			ReleaseAndMaybeThrowAllHeldObjects(throwObjects: false);
			JawSpeed.UnSubscribe(UpdateBitePeriod);
			JawMusclesSizingPower.UnSubscribe(UpdateJawStrength);
			BitingPressure.UnSubscribe(UpdateJawStrength);
			BibiteMassDensity.UnSubscribe(UpdateMouthSizeParameters);
		}

		private bool TrySwallowTarget(GameObject target)
		{
			if (target.CompareTag("pellet"))
			{
				MatterPellet component = target.GetComponent<MatterPellet>();
				if (component.radius > mouthOpening / 2f)
				{
					return false;
				}
				if (component.amount > stomach.availableSpace)
				{
					return false;
				}
				if (component.radius > mouthOpening / 4f)
				{
					if (biteProgress < bitePeriod)
					{
						return false;
					}
					biteProgress -= bitePeriod;
				}
				stomach.AddMatter(component.material, component.amount);
				UnityEngine.Object.Destroy(target);
				return true;
			}
			if (target.CompareTag("bibitePart"))
			{
				BibiteBody bibiteBody = target.GetComponent<BibitePart>().GetMainBody();
				if (bibiteBody.bodyLength > mouthOpening || bibiteBody.stomach == null)
				{
					return false;
				}
				float num = MatterMaterialManager.Meat.AmountOfEnergy(bibiteBody.totalEnergy);
				if (num + bibiteBody.stomach.totalAmount > stomach.availableSpace)
				{
					return false;
				}
				if (bibiteBody.bodyLength > mouthOpening / 2f)
				{
					if (biteProgress < bitePeriod)
					{
						return false;
					}
					biteProgress -= bitePeriod;
				}
				StomachContent[] stomachContents = bibiteBody.stomach.stomachContents;
				for (int i = 0; i < stomachContents.Length; i++)
				{
					StomachContent stomachContent = stomachContents[i];
					stomach.AddMatter(stomachContent.material, stomachContent.amount);
				}
				bibiteBody.stomach.nContent = 0;
				stomach.AddMatter(MatterMaterialManager.Meat, num);
				bibiteBody.Die(swallowed: true);
				return true;
			}
			return false;
		}

		private void MaybeAttack(GameObject target, bool ongoingAttack)
		{
			if (attackedThisFrame || desireToAttack <= 0f)
			{
				return;
			}
			bool flag = target.CompareTag("pellet");
			bool flag2 = target.CompareTag("bibitePart");
			float num = mouthOpening;
			float num2 = biteStrength;
			float num3 = 0f;
			float num4 = 0f;
			if (flag)
			{
				targetPellet = target.GetComponent<MatterPellet>();
				num3 = targetPellet.radius;
				num4 = targetPellet.cohesiveness;
			}
			else
			{
				if (!flag2)
				{
					return;
				}
				otherBody = target.GetComponent<BibitePart>().GetMainBody();
				if (otherBody == null || !otherBody.born)
				{
					return;
				}
				num = biteOpening;
				if (!ongoingAttack)
				{
					num2 = ((!(num2 < otherBody.armorStrength)) ? (num2 - otherBody.armorStrength) : 0f);
				}
				num3 = otherBody.internalsRadius;
				num *= num3 / otherBody.effectiveRadius;
				num4 = MatterMaterialManager.Meat.Cohesiveness;
			}
			if (!ongoingAttack)
			{
				if (biteProgress < bitePeriod)
				{
					return;
				}
				biteProgress -= bitePeriod;
			}
			else if (flag)
			{
				return;
			}
			float num5 = ((num > 0f) ? (num2 / (num * num4)) : 0f);
			float num6 = Mathf.Asin(Mathf.Min(Mathf.Min(num5, 1f) * num / (2f * num3), 1f));
			float num7 = num3 * num3 * (num6 - Mathf.Sin(num6) * Mathf.Cos(num6));
			if (num5 > 1f)
			{
				float num8 = 0.49f * (Mathf.Log(num5 - 1f) - 0.3125f);
				float num9 = MathF.PI / 2f * (1f - 1f / Mathf.Pow(num5, Mathf.Exp(num8 / (Mathf.Pow(16f, num8) - 1f))));
				float num10 = Mathf.Sin(num9);
				float num11 = Mathf.Cos(num9);
				for (int i = 0; i < 2; i++)
				{
					num9 -= (num9 - num5 * num10 * num11) / (1f - num9 * num11 / num10 + num5 * num10 * num10);
					num10 = Mathf.Sin(num9);
					num11 = Mathf.Cos(num9);
				}
				float num12 = num / (2f * num10);
				num7 += num12 * num12 * (num9 - num10 * num11);
			}
			if (flag)
			{
				if (!(desireToAttack > desireToSwallow) || !targetPellet.RipChunkOff(num7, (base.transform.position - targetPellet.transform.position).normalized))
				{
					float num13 = Mathf.Min(num7, stomach.availableSpace);
					if (targetPellet.amount - num13 < minPelletSize)
					{
						num13 = targetPellet.RemoveAmount(targetPellet.amount);
						stomach.AddMatter(targetPellet.material, num13);
					}
					else
					{
						num13 = targetPellet.RemoveAmount(num13);
						stomach.AddMatter(targetPellet.material, num13);
					}
				}
				return;
			}
			if (!ongoingAttack)
			{
				bibitesBitten++;
			}
			attackedThisFrame = true;
			float num14 = bitingDamageFactor * otherBody.maxHealth * num7 / otherBody.realBodyArea;
			if (biteStrength <= otherBody.armorStrength)
			{
				return;
			}
			if (ongoingAttack)
			{
				num14 *= ((bitePeriod > 0f) ? (Time.fixedDeltaTime / (5f * bitePeriod)) : 0f);
			}
			totalDamageDealt += num14;
			if (instaKill)
			{
				num14 = otherBody.health + 0.01f;
			}
			float energy = otherBody.Attack(num14, attackedLastFrame);
			if (otherBody.dying)
			{
				totalMurders++;
				murderedArea += otherBody.baseBodyArea;
				if (totalMurders >= 50 && murderedArea >= 50f * body.baseBodyArea)
				{
					body.BecomeReaper();
				}
			}
			MatterMaterial meat = MatterMaterialManager.Meat;
			Matter matter = new Matter
			{
				Material = meat,
				energy = energy
			};
			if (matter.radius <= mouthOpening / 2f && matter.Amount <= stomach.availableSpace)
			{
				stomach.AddMatter(meat, matter.Amount);
			}
			else
			{
				float num15 = Mathf.Min(matter.Amount, stomach.availableSpace);
				matter.Amount -= num15;
				stomach.AddMatter(meat, num15);
				if (matter.Amount > minPelletSize)
				{
					Vector3 value = (base.transform.position + target.transform.position) / 2f;
					WorldObjectsSpawner instance = WorldObjectsSpawner.Instance;
					Vector3? pos = value;
					float? amount = matter.Amount;
					instance.SpawnMeatPellet(pos, null, amount);
				}
			}
			if (!ongoingAttack && !(otherBody.health <= 0f))
			{
				OnAttack.Invoke(otherBody.gameObject, damageDealt);
				targetRigidbody2D = otherBody.GetComponent<Rigidbody2D>();
				if (!CheckIfTargetIsGrabbed(targetRigidbody2D))
				{
					targetRigidbody2D.AddForce(throwingForceFactor * bitingThrowForceFactor * biteStrength * (otherBody.transform.position - base.transform.position).normalized, ForceMode2D.Impulse);
				}
			}
		}

		private void ReleaseAndMaybeThrowAllHeldObjects(bool throwObjects)
		{
			if (!isStarted || nHeld < 1)
			{
				return;
			}
			float num = links.Sum((FixedJoint2D l) => (!(l != null) || !(l.connectedBody != null)) ? 0f : l.connectedBody.mass);
			float num2 = throwingForceFactor * jawStrength * Mathf.Abs(desireToGrab) * num / (jawMass + num);
			for (int num3 = 0; num3 < nHeld; num3++)
			{
				FixedJoint2D obj = links[num3];
				Rigidbody2D connectedBody = obj.connectedBody;
				connectedBody.GetComponent<GrabbableObject>().Release(this);
				obj.connectedBody = null;
				UnityEngine.Object.Destroy(obj);
				if (throwObjects && !(desireToGrab > -0.25f))
				{
					connectedBody.AddForce(base.transform.parent.up * num2 / nHeld, ForceMode2D.Impulse);
				}
			}
			if (throwObjects && desireToGrab < -0.25f)
			{
				rb.AddForce(-base.transform.parent.up * num2, ForceMode2D.Impulse);
			}
			nHeld = 0;
		}

		private void ReleaseTargetIfHeld(Rigidbody2D target)
		{
			for (int i = 0; i < nHeld; i++)
			{
				if (!(links[i].connectedBody != target))
				{
					target.GetComponent<GrabbableObject>().Release(this);
					UnityEngine.Object.Destroy(links[i]);
					links[i] = links[nHeld - 1];
					nHeld--;
					break;
				}
			}
		}

		private void TryGrabTarget(GrabbableObject targetToGrab)
		{
			if (nHeld < 10)
			{
				targetRigidbody2D = targetToGrab.GetComponent<Rigidbody2D>();
				if (!CheckIfTargetIsGrabbed(targetRigidbody2D))
				{
					targetToGrab.TryGrab(this);
					tempLink = mainBody.AddComponent<FixedJoint2D>();
					tempLink.breakAction = JointBreakAction2D.CallbackOnly;
					tempLink.enableCollision = true;
					tempLink.connectedBody = targetRigidbody2D;
					links[nHeld++] = tempLink;
				}
			}
		}

		public void ReleaseGrabbed(GameObject grabbed)
		{
			tempLink = null;
			for (int i = 0; i < nHeld; i++)
			{
				if (!(links[i] != null) || !(links[i].connectedBody.gameObject != grabbed))
				{
					if (!(links[i] == null))
					{
						UnityEngine.Object.Destroy(links[i]);
						links[i] = links[nHeld - 1];
						nHeld--;
						break;
					}
					links[i] = links[nHeld - 1];
					nHeld--;
				}
			}
		}

		private void Vomit()
		{
			if (body.stomach.isEmpty)
			{
				return;
			}
			int nContent = body.stomach.nContent;
			Vector3 position = base.transform.position;
			float num = Mathf.Abs(swallowOutput / 0.95f);
			List<MatterPellet> list = new List<MatterPellet>();
			for (int i = 0; i < nContent; i++)
			{
				StomachContent stomachContent = body.stomach.stomachContents[i];
				if (!(stomachContent.amount <= minPelletSize))
				{
					float value = body.stomach.RemoveMatter(stomachContent.material, stomachContent.amount * num);
					WorldObjectsSpawner instance = WorldObjectsSpawner.Instance;
					MatterMaterial material = stomachContent.material;
					Vector3? pos = position;
					float? amount = value;
					MatterPellet item = instance.SpawnPelletOfMatter(material, pos, null, amount);
					list.Add(item);
				}
			}
			float num2 = list.Sum((MatterPellet p) => p.mass);
			float num3 = throwingForceFactor * jawStrength * num * num2 / (jawMass + num2);
			foreach (MatterPellet item2 in list)
			{
				item2.GetComponent<Rigidbody2D>().AddForce(base.transform.parent.up * (num3 * item2.mass) / num2, ForceMode2D.Impulse);
			}
		}

		private bool CheckIfTargetIsGrabbed(GameObject target)
		{
			return CheckIfTargetIsGrabbed(target.GetComponent<Rigidbody2D>());
		}

		private bool CheckIfTargetIsGrabbed(Rigidbody2D target)
		{
			if (desireToGrab <= 0f)
			{
				return false;
			}
			for (int i = 0; i < nHeld; i++)
			{
				if (links[i].connectedBody == target)
				{
					return true;
				}
			}
			return false;
		}

		public JObject SaveState()
		{
			return new JObject
			{
				["attackedLastFrame"] = attackedLastFrame,
				["biteProgress"] = biteProgress,
				["bibitesBitten"] = bibitesBitten,
				["totalDamageDealt"] = totalDamageDealt,
				["totalMurders"] = totalMurders,
				["murderedArea"] = murderedArea
			};
		}

		public void LoadState(JObject state)
		{
			if (state["attackedLastFrame"] != null)
			{
				attackedLastFrame = state["attackedLastFrame"].ToObject<bool>();
			}
			if (state["biteProgress"] != null)
			{
				biteProgress = state["biteProgress"].ToObject<float>();
			}
			if (state["bibitesBitten"] != null)
			{
				bibitesBitten = state["bibitesBitten"].ToObject<int>();
			}
			if (state["totalDamageDealt"] != null)
			{
				totalDamageDealt = state["totalDamageDealt"].ToObject<float>();
			}
			if (state["totalMurders"] != null)
			{
				totalMurders = state["totalMurders"].ToObject<int>();
			}
			if (state["murderedArea"] != null)
			{
				murderedArea = state["murderedArea"].ToObject<float>();
			}
		}
	}
}
