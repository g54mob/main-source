using Assets.Scripts.Actors.Player;
using Cpp2ILInjected;
using UnityEngine;

public class SlideEffect : MonoBehaviour
{
	public PlayerMovement playerMovement;

	public GameObject parent;

	public GameObject dirtParticles;

	private float minSpeed = 8f;

	private void Awake()
	{
		Transform transform = base.transform;
		transform.parentInternal = null;
	}

	private unsafe void Update()
	{
		//IL_01de: Expected O, but got Ref
		//IL_0226: Expected O, but got Ref
		//IL_023c: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		Object obj;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerMovement playerMovement = instance.playerMovement;
			obj = playerMovement.rb;
		}
		else
		{
			obj = null;
		}
		GameObject gameObject;
		bool active;
		if (obj != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			if (instance2.character != ECharacter.TonyMcZoom)
			{
				float speed = this.playerMovement.GetSpeed();
				if (this.playerMovement.IsSliding() && !(minSpeed > speed))
				{
					if (!parent.activeInHierarchy)
					{
						parent.SetActive(value: true);
					}
					Transform transform = base.transform;
					Vector3 rbFeetPosition = this.playerMovement.GetRbFeetPosition();
					PlayerMovement playerMovement2 = this.playerMovement;
					Vector3 velocity = playerMovement2.rb.velocity;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v26+4]");
					float num = 0f * 0.8f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v26+8]");
					float num2 = 0f * 0.8f;
					object obj2 = default(object);
					float num3 = (float)obj2 * 0.8f;
					float num4 = num + rbFeetPosition.y;
					float num5 = num2 + rbFeetPosition.z;
					float num6 = num3 + rbFeetPosition.x;
					float num7 = default(float);
					transform.position = (Vector3)(&num7);
					Transform transform2 = base.transform;
					PlayerMovement playerMovement3 = this.playerMovement;
					Vector3 velocity2 = playerMovement3.rb.velocity;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num7));
					object obj3 = default(object);
					transform2.rotation = (Quaternion)(&obj3);
					PlayerMovement playerMovement4 = this.playerMovement;
					if (playerMovement4.grounded && !dirtParticles.activeInHierarchy)
					{
						gameObject = dirtParticles;
						active = true;
						goto IL_0398;
					}
					PlayerMovement playerMovement5 = this.playerMovement;
					if (playerMovement5.grounded || !dirtParticles.activeInHierarchy)
					{
						return;
					}
					gameObject = dirtParticles;
				}
				else
				{
					if (!parent.activeInHierarchy)
					{
						return;
					}
					gameObject = parent;
				}
				active = false;
				goto IL_0398;
			}
		}
		GameObject gameObject2 = base.gameObject;
		active = false;
		gameObject = gameObject2;
		goto IL_0398;
		IL_0398:
		gameObject.SetActive(active);
	}
}
