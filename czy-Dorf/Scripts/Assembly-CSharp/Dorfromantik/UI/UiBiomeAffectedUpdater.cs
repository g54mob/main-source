using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.UI
{
	public class UiBiomeAffectedUpdater : MonoBehaviour
	{
		[SerializeField]
		private bool shouldUpdateAllChildren;

		[SerializeField]
		private List<Ui_BiomeAffected> uiBiomeAffectedsToUpdate = new List<Ui_BiomeAffected>();

		public string fromAnim;

		public string toAnim;

		public string currentModifier;

		public void Start()
		{
			GetComponentsToUpdate();
		}

		public void UpdateBiomeAffectedColors(bool shouldUpdateComponentsFirst = false)
		{
			if (shouldUpdateComponentsFirst)
			{
				GetComponentsToUpdate();
			}
			foreach (Ui_BiomeAffected item in uiBiomeAffectedsToUpdate)
			{
				item.ApplyBiomeAffectedModifiers();
			}
		}

		public void UpdateCurrentBiomeAffectedColors()
		{
			UpdateBiomeAffectedColors();
		}

		public void DBG_FromAnimation(string fromAnim)
		{
			this.fromAnim = fromAnim;
		}

		public void DBG_ToAnimation(string toAnim)
		{
			this.toAnim = toAnim;
		}

		public void DBG_Modifier(string currentModifier)
		{
			this.currentModifier = currentModifier;
		}

		public void DBG_Logger()
		{
			Debug.Log("(dro) From " + fromAnim + " to " + toAnim + ". Current Modifier = " + currentModifier + ".");
		}

		private void GetComponentsToUpdate()
		{
			if (shouldUpdateAllChildren)
			{
				uiBiomeAffectedsToUpdate = Enumerable.ToList(GetComponentsInChildren<Ui_BiomeAffected>());
			}
		}
	}
}
