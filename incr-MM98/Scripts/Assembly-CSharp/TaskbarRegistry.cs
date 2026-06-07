using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct TaskbarRegistry
{
	public Button startMenu;

	public ButtonWrapper dashboard;

	public ButtonWrapper upgrades;

	public ButtonWrapper world;

	public ButtonWrapper debugger;

	public ButtonWrapper auction;

	public ButtonWrapper sequel;

	public ButtonWrapper research;

	public GameObject upgradesNotification;

	public GameObject debuggerNotification;

	public GameObject worldNotification;

	public GameObject auctionNotification;

	public GameObject sequelNotification;
}
