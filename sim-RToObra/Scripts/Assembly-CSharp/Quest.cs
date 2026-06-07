using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
	public string id;

	public int nextSaveBit;

	public bool persist = true;

	public List<QuestAtom> atoms = new List<QuestAtom>();

	private bool[] workStack = new bool[20];

	private int runningBits
	{
		get
		{
			int num = 0;
			foreach (QuestAtom atom in atoms)
			{
				if (atom.running)
				{
					num |= 1 << atom.saveBit;
				}
			}
			return num;
		}
		set
		{
			foreach (QuestAtom atom in atoms)
			{
				atom.running = (value & (1 << atom.saveBit)) != 0;
			}
		}
	}

	private void Start()
	{
		if (persist)
		{
			int stat = SaveData.it.GetStat(id, -1);
			if (stat != -1)
			{
				runningBits = stat;
				return;
			}
		}
		foreach (QuestAtom atom in atoms)
		{
			if (atom.runAtBoot)
			{
				atom.running = true;
			}
		}
	}

	private void LateUpdate()
	{
		foreach (QuestAtom atom in atoms)
		{
			if (atom.running && atom.RunChecks(workStack))
			{
				atom.running = false;
				atom.ApplyActions(this, persist);
				if (persist)
				{
					SaveData.it.SetStat(id, runningBits);
				}
			}
		}
	}

	public QuestAtom FindAtom(string atomGuid)
	{
		foreach (QuestAtom atom in atoms)
		{
			if (atom.guid == atomGuid)
			{
				return atom;
			}
		}
		return null;
	}

	public void SetAtomRunning(string atomGuid, bool running)
	{
		foreach (QuestAtom atom in atoms)
		{
			if (atomGuid == "*" || atom.guid == atomGuid)
			{
				atom.running = running;
			}
		}
	}
}
