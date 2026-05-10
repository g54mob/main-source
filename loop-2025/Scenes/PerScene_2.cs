using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

using SPACE_UTIL;

namespace GptDeepResearch
{
	public class PerScene_2 : GameControllerBase
	{
		[Header("Player References")]
		public Transform playerTransform;
		public v2 playerPos;

		[Header("goal reference")]
		public Transform goalTransform;
		public v2 goalPos;

		[Header("blocks reference")]
		public Transform blockParent;
		public List<v2> BLOCK_POS;

		[Header("submit reference")]
		[SerializeField] Button correctButton;
		[SerializeField] Button incorrectButton;


		public float moveSpeed = 2f;
		private Vector3 initialPlayerPosition;


		protected override void Awake()
		{
			// Store initial positions for reset
			if (playerTransform != null)
			{
				initialPlayerPosition = playerTransform.position;
			}

			this.correctButton.onClick.AddListener(() =>
			{
				SceneManager.LoadNextScene();
			});

			if (this.goalTransform != null)
			{
				this.goalPos = new v2()
				{
					x = Mathf.RoundToInt(this.goalTransform.position.x),
					y = Mathf.RoundToInt(this.goalTransform.position.y),
				}
				;
			}

			if(this.blockParent != null)
			{
				BLOCK_POS = new List<v2>();
				for (int i0 = 0; i0 < this.blockParent.childCount; i0 += 1)
					BLOCK_POS.Add(this.blockParent.GetChild(i0).position);
			}

			//
			base.Awake();
		}


		private void Update()
		{
			this.playerPos = this.playerTransform.position;
		}

		// ADD to RegisterCommands method in ExampleSceneController (around line 150):
		protected override void RegisterCommands()
		{
			// new >>
			RegisterAction("say", SayCommand);
			RegisterAction("submit", SubmitCommand);
			RegisterAction("move", MoveCommand);

			RegisterPredicate("is_player", IsPlayerCommand);
			RegisterPredicate("is_goal", IsGoalCommand);
			RegisterPredicate("is_block", IsBlockCommand);

			RegisterValueGetter("get_goal_x", GetGoalXCommand);
			RegisterValueGetter("get_goal_y", GetGoalYCommand);
			// << new

			// Register action commands (no return value)
			RegisterAction("move_name", MoveNameCommand);
			RegisterAction("collect", CollectCommand);

			// Register predicate commands (return bool)
			// RegisterPredicate("is_block", IsBlockCommand);
			RegisterPredicate("can_move", CanMoveCommand);

			// ADD: Register value getter commands (return int/string/object)
			RegisterValueGetter("get_pos_x", GetPosXCommand);
			RegisterValueGetter("get_pos_y", GetPosYCommand);
			RegisterValueGetter("get_dialogue", GetDialogueCommand);
		}

		public override IEnumerator SceneReset()
		{
			// Reset player position
			if (playerTransform != null)
			{
				playerTransform.position = initialPlayerPosition;
			}

			// Add any other scene reset logic here
			// e.g., reset inventory, clear collected items, etc.
			this.playerTransform.GetDepthLeaf("canvas").gameObject.SetActive(false);

			yield return null; // Yield at least once
		}

		#region Custom Actions, Predicates, Integer return

		#region say
		[Header("say")]
		[SerializeField] float say_duration = 3f;
		private IEnumerator SayCommand(object[] args)
		{

			if (args.Length != 1)
				throw new Exception("say() takes exactly 1 argument");

			if (playerTransform == null)
				Debug.Log("reference the Player Transform in inspector");

			string str = args[0].ToString(); // REMOVED .ToLower() - preserve original case

			// text initialize
			this.playerTransform.GetDepthLeaf("canvas").gameObject.SetActive(true);
			TextMeshProUGUI tm = this.playerTransform.GetDepthLeaf("text").gameObject.GC<TextMeshProUGUI>();
			tm.text = str;


			#region what works

			// time.deltatime isnt working as intended
			/*
				what's working as intended
					Time.realtimeSinceStartup - startTime
					yield return null					-> (waits exactly around 1 frame ms)
					yield return new WaitForSeconds(2f) -> (waits exactly around 2 second)
			*/


			#endregion

			// FIXED: Use real time tracking instead of Time.deltaTime
			Debug.Log("started say counter");
			float startTime = Time.realtimeSinceStartup;

			yield return tm.typewriter_effect(waitInBetween: 1f / 20);
			while (Time.realtimeSinceStartup - startTime <= say_duration)
			{
				float t = (Time.realtimeSinceStartup - startTime) / this.say_duration;
				// do somthng with t

				// this.playerTransform.position = Z.lerp(Vector3.zero, Vector3.up, t);

				yield return null; // This will be handled by the interpreter's step delay
			}

			Debug.Log("ended say counter");
			if (tm.text.Length <= 2)
				this.playerTransform.GetDepthLeaf("canvas").gameObject.SetActive(false);
		}
		#endregion

		#region submit
		[Header("submit")]
		[SerializeField] float submit_duration = 1f;
		[SerializeField] bool isSubmitCorrect = false;
		[SerializeField] string submitValue = "1000";

		private IEnumerator SubmitCommand(object[] args)
		{
			if (args.Length == 0)
			{
				yield return this.submitAnim();
			}
			else if(args.Length == 1)
			{
				if (this.submitValue == "1000")
				{
					yield return this.submitAnim();
				}
				else
				{
					string str = args[0].ToString().ToLower();
					if (str == this.submitValue.ToLower())
						yield return this.submitAnim();
				}
			}
			else
				throw new Exception("submit() takes either 1 or no argument");
		}

		string[] affirmations = new string[]
		{
			"well done",
			"great",
			"correct",
			"nice",
			"perfect",
			"awesome",
			"solid",
			"clean",
			"tight",
			"sharp",
			"cool",
			"crisp",
			"legit",
			"dope",
			"clear",
			"smart",
			"neat"
		};
		string get_random_affirmation { get { return affirmations[UnityEngine.Random.Range(0, affirmations.Length)]; } }

		IEnumerator submitAnim()
		{
			this.isSubmitCorrect = (goalPos == playerPos);

			// submitCorrect >>
			if (this.isSubmitCorrect == true)
			{
				this.correctButton.gameObject.SetActive(true);

				TextMeshProUGUI tm = correctButton.gameObject.NameStartsWith("text").GC<TextMeshProUGUI>();
				tm.text = $"{this.get_random_affirmation}, next level ->"; yield return tm.typewriter_effect(1f / 20);

				this.incorrectButton.gameObject.SetActive(false);
			}
			// << submitCorrect
			else
			{
				this.incorrectButton.gameObject.SetActive(true);

				TextMeshProUGUI tm = incorrectButton.gameObject.NameStartsWith("text").GC<TextMeshProUGUI>();
				yield return new WaitForSeconds(0.4f);
				tm.text = "that is incorrect x"; yield return tm.typewriter_effect(1f / 20);

				this.correctButton.gameObject.SetActive(false);
			}
			yield return new WaitForSeconds(this.submit_duration);

			if (this.isSubmitCorrect == false)
			{
				this.correctButton.gameObject.SetActive(false);
				this.incorrectButton.gameObject.SetActive(false);
				yield return this.SceneReset();
			}
			Debug.Log("submit() performed");
		}

		#endregion

		#region move
		[Header("move")]
		[SerializeField] float move_duration = 0.3f;

		private IEnumerator MoveCommand(object[] args)
		{
			if (args.Length == 2)
			{
				string dx = args[0].ToString().ToLower();
				string dy = args[1].ToString().ToLower();

				Debug.Log(dx + "//" + dy);

				if (!(dx.fmatch(@"^([-+]?1|0)$") && dy.fmatch(@"^([-+]?1|0)$")))
				{
					throw new Exception("invalid direction x, y can only be -1, 0, +1");
				}
				Vector3 moveVector = new Vector2(dx.parseInt(), dy.parseInt());

				yield return util_moveSquashAnim(this.playerTransform, duration: this.move_duration, moveVector, 0.9f, 0.9f);
			}
			else if (args.Length == 1)
			{
				string direction = args[0].ToString().ToLower();
				Vector3 moveVector = Vector3.zero;

				switch (direction)
				{
					case "up": moveVector = Vector3.up; break;
					case "down": moveVector = Vector3.down; break;
					case "left": moveVector = Vector3.left; break;
					case "right": moveVector = Vector3.right; break;
					default:
						throw new Exception($"Invalid dir: {direction}, can only be 'east', 'west', 'north', 'south'");
				}

				yield return util_moveSquashAnim(this.playerTransform, duration: this.move_duration, moveVector, 0.9f, 0.9f);
			}
			else
			{
				throw new Exception("move() can take only either 1 or 2 argument");
			}

			#region commented old method
			/*
			if (playerTransform != null)
			{
				Vector3 startPos = playerTransform.position;
				Vector3 endPos = startPos + moveVector;
				float elapsed = 0f;

				while (elapsed < 1f)
				{
					elapsed += Time.deltaTime * moveSpeed;
					playerTransform.position = Vector3.Lerp(startPos, endPos, elapsed);
					yield return null;
				}

				playerTransform.position = endPos;
			}
			*/
			#endregion
		}
		IEnumerator util_moveSquashAnim(Transform transform, float duration, Vector3 targetOffset, float squashAmount, float stretchAmount)
		{
			// 2) Setup timing
			float startTime = Time.realtimeSinceStartup;
			float endTime = startTime + duration;

			// Cache original transform values
			Vector3 origPos = transform.position;
			Vector3 targetPos = origPos + targetOffset;
			Vector3 origScale = transform.localScale;

			// 3) Animate until duration elapses
			while (Time.realtimeSinceStartup < endTime)
			{
				float elapsed = Time.realtimeSinceStartup - startTime;
				float tRaw = Mathf.Clamp01(elapsed / duration);

				// apply an ease‐in‐out (smoothstep)
				float t = tRaw * tRaw * (3f - 2f * tRaw);

				// 3a) Position interpolation
				transform.position = Vector3.LerpUnclamped(origPos, targetPos, t);

				// 3b) Squash & stretch:
				//    - first half: squat down, then second half: stretch up, then revert
				float squashT;
				if (t < 0.5f)
				{
					// squash phase
					squashT = Mathf.InverseLerp(0f, 0.5f, t);
					transform.NameStartsWith("visual").localScale = new Vector3(
						Mathf.Lerp(origScale.x, origScale.x * (2 - squashAmount), squashT),
						Mathf.Lerp(origScale.y, origScale.y * squashAmount, squashT),
						Mathf.Lerp(origScale.z, origScale.z * (2 - squashAmount), squashT)
					);
				}
				else
				{
					// stretch + return
					squashT = Mathf.InverseLerp(0.5f, 1f, t);
					float yScale = Mathf.Lerp(origScale.y * stretchAmount, origScale.y, squashT);
					float xzScale = Mathf.Lerp(origScale.x * (2 - stretchAmount), origScale.x, squashT);
					transform.NameStartsWith("visual").localScale = new Vector3(xzScale, yScale, xzScale);
				}

				yield return null; // interpreter step delay
			}

			// 4) Ensure final state is exactly at target and normal scale
			transform.position = targetPos;
			transform.NameStartsWith("visual").localScale = origScale;
		}

		#endregion


		#region is_goal(x, y)
		private IEnumerator IsGoalCommand(object[] args)
		{
			if (args.Length == 2)
			{
				string str_x = args[0].ToString().ToLower();
				string str_y = args[1].ToString().ToLower();

				Debug.Log(str_x + "//" + str_y);

				// @"^([-+]?1|0)$"
				// ^-?\d+$

				if (!(str_x.fmatch(@"^([-+]?\d+)$") && str_y.fmatch(@"^([-+]?\d+)$")))
				{
					throw new Exception($"invalid direction {str_x}, {str_y}");
				}

				v2 pos = new v2(str_x.parseInt(), str_y.parseInt() );

				bool result = (pos == this.goalPos);
				SetPredicateResult("is_goal", result);
				yield return null;
			}
			else
			{
				throw new Exception("is_goal() can exactly 2 argument");
			}

			//if (args.Length != 0)
			//	throw new Exception("is_player() takes no arguments");
			//yield return null;
			//bool result = (this.playerTransform.gameObject.name.ToLower() == "player");
			//SetPredicateResult("is_player", result);
		}
		#endregion

		#region is_block(x, y)
		private IEnumerator IsBlockCommand(object[] args)
		{
			if (args.Length == 2)
			{
				string str_x = args[0].ToString().ToLower();
				string str_y = args[1].ToString().ToLower();

				Debug.Log(str_x + "//" + str_y);

				// @"^([-+]?1|0)$"
				// ^-?\d+$

				if (!(str_x.fmatch(@"^([-+]?\d+)$") && str_y.fmatch(@"^([-+]?\d+)$")))
				{
					throw new Exception($"invalid direction {str_x}, {str_y}");
				}

				v2 pos = new v2(str_x.parseInt(), str_y.parseInt());

				bool result = false;
				foreach (v2 block_pos in this.BLOCK_POS)
					if (block_pos == pos)
					{
						result = true;
						break;
					}

				SetPredicateResult("is_block", result);
				yield return null;
			}
			else
			{
				throw new Exception("is_goal() can exactly 2 argument");
			}

			//if (args.Length != 0)
			//	throw new Exception("is_player() takes no arguments");
			//yield return null;
			//bool result = (this.playerTransform.gameObject.name.ToLower() == "player");
			//SetPredicateResult("is_player", result);
		}
		#endregion

		#region get_goal_x, _y
		private object GetGoalXCommand(object[] args)
		{
			if (args.Length != 0)
				throw new Exception("get_goal_x() takes no args");

			return this.goalPos.x;
		}
		private object GetGoalYCommand(object[] args)
		{
			if (args.Length != 0)
				throw new Exception("get_goal_y() takes no args");

			return this.goalPos.y;
		} 
		#endregion


		#region is_player()
		private IEnumerator IsPlayerCommand(object[] args)
		{
			//if (args.Length != 2)
			//	throw new Exception("is_block() takes exactly 2 arguments");

			//float x = Convert.ToSingle(args[0]);
			//float y = Convert.ToSingle(args[1]);

			//// Example: Check if position is blocked
			//// This could involve raycasting, collision detection, etc.
			//Vector3 checkPos = new Vector3(x, y, 0);

			//// Simulate some async work
			//yield return new WaitForSeconds(0.1f);

			//// Example logic: check if there's a collider at this position
			//Collider2D collider = Physics2D.OverlapPoint(checkPos);
			//bool result = collider != null && collider.CompareTag("Block");

			// Set the result using the helper method
			//SetPredicateResult("is_player", result);

			if (args.Length != 0)
				throw new Exception("is_player() takes no arguments");
			yield return null;
			bool result = (this.playerTransform.gameObject.name.ToLower() == "player");
			SetPredicateResult("is_player", result);
		} 
		#endregion
		#endregion



		#region Reference Commands
		// Example action command implementations
		private IEnumerator MoveNameCommand(object[] args)
		{
			if (args.Length != 1)
				throw new Exception("move_name() takes exactly 1 argument, one of 'up', 'right', 'down', 'left'");

			string direction = args[0].ToString().ToLower();
			Vector3 moveVector = Vector3.zero;

			switch (direction)
			{
				case "up": moveVector = Vector3.up; break;
				case "down": moveVector = Vector3.down; break;
				case "left": moveVector = Vector3.left; break;
				case "right": moveVector = Vector3.right; break;
				default: throw new Exception($"Invalid dir: {direction}");
			}

			yield return util_moveSquashAnim(this.playerTransform, duration: this.move_duration, moveVector, 0.9f, 0.9f);

			#region commented old method
			/*
			if (playerTransform != null)
			{
				Vector3 startPos = playerTransform.position;
				Vector3 endPos = startPos + moveVector;
				float elapsed = 0f;

				while (elapsed < 1f)
				{
					elapsed += Time.deltaTime * moveSpeed;
					playerTransform.position = Vector3.Lerp(startPos, endPos, elapsed);
					yield return null;
				}

				playerTransform.position = endPos;
			}
			*/
			#endregion
		}

		private IEnumerator CollectCommand(object[] args)
		{
			if (args.Length != 1)
				throw new Exception("collect() takes exactly 1 argument");

			string itemName = args[0].ToString();

			// Example: Find and collect item
			GameObject item = GameObject.Find(itemName);
			if (item != null)
			{
				// Animate collection
				Vector3 originalScale = item.transform.localScale;
				float elapsed = 0f;

				while (elapsed < 0.5f)
				{
					elapsed += Time.deltaTime;
					float scale = Mathf.Lerp(1f, 0f, elapsed / 0.5f);
					item.transform.localScale = originalScale * scale;
					yield return null;
				}

				Destroy(item);
			}
		}

		// FIXED: Example predicate command implementations
		private IEnumerator IsBlockCommand_1(object[] args)
		{
			if (args.Length != 2)
				throw new Exception("is_block() takes exactly 2 arguments");

			float x = Convert.ToSingle(args[0]);
			float y = Convert.ToSingle(args[1]);

			// Example: Check if position is blocked
			// This could involve raycasting, collision detection, etc.
			Vector3 checkPos = new Vector3(x, y, 0);

			// Simulate some async work
			yield return new WaitForSeconds(0.1f);

			// Example logic: check if there's a collider at this position
			Collider2D collider = Physics2D.OverlapPoint(checkPos);
			bool result = collider != null && collider.CompareTag("Block");

			// Set the result using the helper method
			SetPredicateResult("is_block", result);
		}

		private IEnumerator CanMoveCommand(object[] args)
		{
			if (args.Length != 1)
				throw new Exception("can_move() takes exactly 1 argument");

			string direction = args[0].ToString().ToLower();

			if (playerTransform == null)
			{
				SetPredicateResult("can_move", false);
				yield break;
			}

			Vector3 checkDirection = Vector3.zero;
			switch (direction)
			{
				case "up": checkDirection = Vector3.up; break;
				case "down": checkDirection = Vector3.down; break;
				case "left": checkDirection = Vector3.left; break;
				case "right": checkDirection = Vector3.right; break;
				default:
					SetPredicateResult("can_move", false);
					yield break;
			}

			// Check if movement is possible
			Vector3 checkPos = playerTransform.position + checkDirection;

			// Simulate some async work
			yield return new WaitForSeconds(0.05f);

			// Example: check bounds or obstacles
			bool canMove = true; // Your logic here

			SetPredicateResult("can_move", canMove);
		}

		// ADD new value getter command implementations after existing methods:
		private object GetPosXCommand(object[] args)
		{
			if (args.Length != 0)
				throw new Exception("get_pos_x() takes no arguments");

			return playerTransform != null ? Mathf.RoundToInt(playerTransform.position.x) : 0;
		}

		private object GetPosYCommand(object[] args)
		{
			if (args.Length != 0)
				throw new Exception("get_pos_y() takes no arguments");

			return playerTransform != null ? Mathf.RoundToInt(playerTransform.position.y) : 0;
		}

		private object GetDialogueCommand(object[] args)
		{
			if (args.Length != 1)
				throw new Exception("get_dialogue() takes exactly 1 argument");

			string npcName = args[0].ToString();
			// Example dialogue system integration
			return $"Hello from {npcName}!";
		} 
		#endregion
	}
}
