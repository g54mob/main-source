using System;
using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public int npcIndex;

	[SerializeField]
	private Animator animator;

	private float currentSpeed;

	public NpcHeadIk headIk;

	public string npcName;

	public NpcStat stat;

	public int affinityPoint;

	public Transform hand;

	public bool partTimeRequest;

	public bool cookingDeliveryRequest;

	public Food wantedFood;

	public Transform[] wayPoints;

	private int current;

	public float speed = 3f;

	private bool isMoving;

	private bool isMovingBack;

	private NpcHouse house;

	public bool haveMet;

	public Paint ownedStuff;

	public Item wantedStuff;

	protected Vector3 dirToPlayer;

	protected bool isTalking;

	protected Quaternion targetRotation;

	private void Start()
	{
		animator = GetComponent<Animator>();
		AffinityPointChanged(UnityEngine.Random.Range(1, 2));
		affinityPoint = 0;
		haveMet = false;
		QuestManager.S.OnQuestStarted += Qm_OnQuestStarted;
		QuestUI.OnCookingDeliveryStart += QuestUI_OnCookingDeliveryStart;
	}

	private void OnDestroy()
	{
		QuestManager.S.OnQuestStarted -= Qm_OnQuestStarted;
		QuestUI.OnCookingDeliveryStart -= QuestUI_OnCookingDeliveryStart;
	}

	private void Qm_OnQuestStarted(QuestData obj)
	{
		if (obj.questType == QuestType.Reward && obj.pay == npcIndex)
		{
			partTimeRequest = true;
		}
	}

	private void QuestUI_OnCookingDeliveryStart(int arg1, Food arg2)
	{
		if (arg1 == npcIndex)
		{
			partTimeRequest = true;
			cookingDeliveryRequest = true;
			wantedFood = arg2;
		}
	}

	private void Update()
	{
		if (isTalking && dirToPlayer.sqrMagnitude > 0.001f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRotation, Time.deltaTime * 5f);
		}
		if (isMoving)
		{
			MoveFortheDoor();
		}
		if (isMovingBack)
		{
			MoveBack();
		}
	}

	public void StartConversation()
	{
		GameManager.S.StartConversation(this);
		isTalking = true;
		dirToPlayer = Camera.main.transform.position - base.transform.position;
		dirToPlayer.y = 0f;
		targetRotation = Quaternion.LookRotation(dirToPlayer);
		if (FirstPersonController.S.rcControl)
		{
			headIk.headIkTarget = FirstPersonController.S.currentRC.transform;
		}
		else if (stat.place == NpcPlace.House)
		{
			headIk.headIkTarget = Camera.main.transform;
		}
		else
		{
			headIk.headIkTarget = FirstPersonController.S.playerCamPos;
		}
		headIk.ikActive = true;
	}

	public virtual void ConversationEnd()
	{
		StartCoroutine(CloseDoorDelay());
		isTalking = false;
		if (!FirstPersonController.S.rcControl)
		{
			FirstPersonController.S.canControl = true;
		}
		house.doorCam.Priority = 0;
	}

	public virtual void ConversationEndKickOut()
	{
		StartCoroutine(CloseDoorDelay());
		isTalking = false;
		house.doorCam.Priority = 0;
	}

	public virtual void ConversationEndShop()
	{
	}

	public void AttainItem(GameObject item)
	{
		if (item.TryGetComponent<Rigidbody>(out var component))
		{
			if (!component.isKinematic)
			{
				component.linearVelocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.isKinematic = true;
		}
		Collider[] componentsInChildren = item.GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = false;
		}
		item.transform.parent = hand;
		item.transform.localPosition = Vector3.zero;
		item.transform.localRotation = Quaternion.identity;
		item.gameObject.SetActive(value: false);
	}

	public void AffinityPointChanged(int point)
	{
		affinityPoint += point;
		if (affinityPoint == 2)
		{
			stat.npcAffinity = NpcAffinity.Friendly;
			affinityPoint = 2;
		}
		else if (affinityPoint == 1)
		{
			stat.npcAffinity = NpcAffinity.Interest;
		}
	}

	public void GiveRocketAnim()
	{
		headIk.animator.CrossFade("Give", 0.1f);
	}

	public void CheckDoor(NpcHouse npcHouse)
	{
		GameManager.S.player.canControl = false;
		isMoving = true;
		isMovingBack = false;
		house = npcHouse;
	}

	public void MoveFortheDoor()
	{
		if (wayPoints.Length == 0)
		{
			return;
		}
		Transform transform = wayPoints[current];
		Vector3 vector = new Vector3(transform.position.x, base.transform.position.y, transform.position.z);
		Vector3 normalized = (vector - base.transform.position).normalized;
		if (normalized != Vector3.zero)
		{
			Quaternion b = Quaternion.LookRotation(normalized);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 5f);
		}
		base.transform.position = Vector3.MoveTowards(base.transform.position, vector, speed * Time.deltaTime);
		currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime);
		animator.SetFloat("Speed", currentSpeed);
		if (Vector3.Distance(base.transform.position, vector) < 0.1f)
		{
			if (current < wayPoints.Length - 1)
			{
				current++;
				return;
			}
			currentSpeed = 0f;
			animator.SetFloat("Speed", currentSpeed);
			isMoving = false;
			house.Opened();
			StartConversation();
		}
	}

	public void MoveBack()
	{
		if (wayPoints.Length == 0)
		{
			return;
		}
		Transform transform = wayPoints[current];
		Vector3 vector = new Vector3(transform.position.x, base.transform.position.y, transform.position.z);
		if (Vector3.Distance(base.transform.position, vector) < 0.1f)
		{
			if (current <= 0)
			{
				currentSpeed = 0f;
				animator.SetFloat("Speed", currentSpeed);
				isMovingBack = false;
				return;
			}
			current--;
			transform = wayPoints[current];
			vector = new Vector3(transform.position.x, base.transform.position.y, transform.position.z);
		}
		Vector3 normalized = (vector - base.transform.position).normalized;
		if (normalized != Vector3.zero)
		{
			Quaternion b = Quaternion.LookRotation(normalized);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 5f);
		}
		base.transform.position = Vector3.MoveTowards(base.transform.position, vector, speed * Time.deltaTime);
		currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime);
		animator.SetFloat("Speed", currentSpeed);
	}

	private IEnumerator CloseDoorDelay()
	{
		yield return new WaitForSeconds(0.3f);
		house.Closed();
	}

	public void NpcResetPos()
	{
		isMovingBack = true;
		headIk.ikActive = false;
		headIk.lastTargetPos = headIk.headIkTarget.position;
		headIk.headIkTarget = null;
	}

	private T GetRandomEnumValue<T>()
	{
		Array values = Enum.GetValues(typeof(T));
		return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
	}
}
