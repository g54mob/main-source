using UnityEngine;
using UnityHFSM;

[RequireComponent(typeof(AirplaneWaypointMover))]
public class AirplaneAI : MonoBehaviour
{
	[Header("Режим атаки")]
	public AttackMode attackMode;

	[Header("Виявлення гравця")]
	public float detectionRange = 500f;

	public float detectionAngle = 70f;

	public float losePlayerRange = 700f;

	[Header("Debug")]
	public bool showGizmos = true;

	private AirplaneWaypointMover mover;

	private AirplaneBombDropper bombDropper;

	private AirToGroundMissileLauncher missileLauncher;

	private Rigidbody rb;

	private Transform playerTransform;

	private StateMachine<string> fsm;

	private AggressionState aggressionState;

	private PostAttackState postAttackState;

	private void Start()
	{
		mover = GetComponent<AirplaneWaypointMover>();
		bombDropper = GetComponent<AirplaneBombDropper>();
		missileLauncher = GetComponent<AirToGroundMissileLauncher>();
		rb = GetComponent<Rigidbody>();
		GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
		if (gameObject != null)
		{
			playerTransform = gameObject.transform;
		}
		else
		{
			Debug.LogWarning("[AirplaneAI] Player не знайдено!");
		}
		ValidateWeapon();
		BuildFSM();
	}

	private void ValidateWeapon()
	{
		if (attackMode == AttackMode.BombDropper && bombDropper == null)
		{
			Debug.LogError("[AirplaneAI] AttackMode=BombDropper але AirplaneBombDropper відсутній!");
		}
		if (attackMode == AttackMode.AirToGroundMissile && missileLauncher == null)
		{
			Debug.LogError("[AirplaneAI] AttackMode=AirToGroundMissile але AirToGroundMissileLauncher відсутній!");
		}
	}

	private void Update()
	{
		fsm?.OnLogic();
	}

	private void BuildFSM()
	{
		aggressionState = new AggressionState(mover, bombDropper, missileLauncher, attackMode, base.transform, playerTransform, rb);
		postAttackState = new PostAttackState(mover);
		fsm = new StateMachine<string>();
		fsm.AddState("Patrol", new PatrolState(mover));
		fsm.AddState("Aggression", aggressionState);
		fsm.AddState("PostAttack", postAttackState);
		fsm.AddTransition("Patrol", "Aggression", (Transition<string> _) => CanSeePlayer());
		aggressionState.OnSalvoFired += delegate
		{
			fsm.RequestStateChange("PostAttack");
		};
		fsm.AddTransition("PostAttack", "Aggression", (Transition<string> _) => postAttackState.WaypointReached && CanSeePlayer());
		fsm.AddTransition("PostAttack", "Patrol", (Transition<string> _) => postAttackState.WaypointReached && !CanSeePlayer());
		fsm.AddTransition("Aggression", "Patrol", (Transition<string> _) => playerTransform == null || (!CanSeePlayer() && Vector3.Distance(base.transform.position, playerTransform.position) > losePlayerRange));
		fsm.SetStartState("Patrol");
		fsm.Init();
	}

	private bool CanSeePlayer()
	{
		if (playerTransform == null)
		{
			return false;
		}
		if (Vector3.Distance(base.transform.position, playerTransform.position) > detectionRange)
		{
			return false;
		}
		return Vector3.Angle(base.transform.forward, (playerTransform.position - base.transform.position).normalized) <= detectionAngle;
	}
}
