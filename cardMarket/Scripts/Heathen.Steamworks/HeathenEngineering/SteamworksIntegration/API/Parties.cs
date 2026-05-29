using System;
using System.Collections.Generic;
using System.Linq;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration.API
{
	public static class Parties
	{
		public static class Client
		{
			private static ReservationNotificationCallbackEvent eventReservationNotificationCallback = new ReservationNotificationCallbackEvent();

			private static ActiveBeaconsUpdatedEvent eventActiveBeaconsUpdated = new ActiveBeaconsUpdatedEvent();

			private static AvailableBeaconLocationsUpdatedEvent eventAvailableBeaconLocationsUpdated = new AvailableBeaconLocationsUpdatedEvent();

			private static CallResult<CreateBeaconCallback_t> m_CreateBeaconCallback_t;

			private static CallResult<ChangeNumOpenSlotsCallback_t> m_ChangeNumOpenSlotsCallback_t;

			private static CallResult<JoinPartyCallback_t> m_JoinPartyCallback_t;

			private static Callback<ReservationNotificationCallback_t> m_ReservationNotificationCallback_t;

			private static Callback<ActiveBeaconsUpdated_t> m_ActiveBeaconsUpdated_t;

			private static Callback<AvailableBeaconLocationsUpdated_t> m_AvailableBeaconLocationsUpdated_t;

			private static List<ReservationNotificationCallback_t> reservations;

			private static List<PartyBeaconID_t> createdBeacons;

			public static PartyBeaconID_t[] MyBeacons => createdBeacons?.ToArray();

			public static ReservationNotificationCallback_t[] Reservations => reservations?.ToArray();

			public static ReservationNotificationCallbackEvent EventReservationNotificationCallback
			{
				get
				{
					if (m_ReservationNotificationCallback_t == null)
					{
						m_ReservationNotificationCallback_t = Callback<ReservationNotificationCallback_t>.Create(ReservationCallback);
					}
					return eventReservationNotificationCallback;
				}
			}

			public static ActiveBeaconsUpdatedEvent EventActiveBeaconsUpdated
			{
				get
				{
					if (m_ActiveBeaconsUpdated_t == null)
					{
						m_ActiveBeaconsUpdated_t = Callback<ActiveBeaconsUpdated_t>.Create(eventActiveBeaconsUpdated.Invoke);
					}
					return eventActiveBeaconsUpdated;
				}
			}

			public static AvailableBeaconLocationsUpdatedEvent EventAvailableBeaconLocationsUpdated
			{
				get
				{
					if (m_AvailableBeaconLocationsUpdated_t == null)
					{
						m_AvailableBeaconLocationsUpdated_t = Callback<AvailableBeaconLocationsUpdated_t>.Create(eventAvailableBeaconLocationsUpdated.Invoke);
					}
					return eventAvailableBeaconLocationsUpdated;
				}
			}

			[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
			private static void Init()
			{
				eventReservationNotificationCallback = new ReservationNotificationCallbackEvent();
				eventActiveBeaconsUpdated = new ActiveBeaconsUpdatedEvent();
				eventAvailableBeaconLocationsUpdated = new AvailableBeaconLocationsUpdatedEvent();
				m_CreateBeaconCallback_t = null;
				m_ChangeNumOpenSlotsCallback_t = null;
				m_JoinPartyCallback_t = null;
				m_ReservationNotificationCallback_t = null;
				m_AvailableBeaconLocationsUpdated_t = null;
				m_ActiveBeaconsUpdated_t = null;
				reservations = null;
				createdBeacons = null;
			}

			public static SteamPartyBeaconLocation_t[] GetAvailableBeaconLocations()
			{
				SteamParties.GetNumAvailableBeaconLocations(out var puNumLocations);
				SteamPartyBeaconLocation_t[] array = new SteamPartyBeaconLocation_t[puNumLocations];
				SteamParties.GetAvailableBeaconLocations(array, puNumLocations);
				return array;
			}

			public static void CreateBeacon(uint openSlots, ref SteamPartyBeaconLocation_t location, string connectionString, string metadata, Action<CreateBeaconCallback_t, bool> callback)
			{
				if (callback == null)
				{
					return;
				}
				if (m_CreateBeaconCallback_t == null)
				{
					m_CreateBeaconCallback_t = CallResult<CreateBeaconCallback_t>.Create();
				}
				SteamAPICall_t hAPICall = SteamParties.CreateBeacon(openSlots, ref location, connectionString, metadata);
				m_CreateBeaconCallback_t.Set(hAPICall, delegate(CreateBeaconCallback_t r, bool e)
				{
					if (!e && r.m_eResult == EResult.k_EResultOK)
					{
						if (createdBeacons == null)
						{
							createdBeacons = new List<PartyBeaconID_t>();
						}
						createdBeacons.Add(r.m_ulBeaconID);
					}
					callback(r, e);
				});
			}

			public static void OnReservationCompleted(PartyBeaconID_t beacon, CSteamID user)
			{
				SteamParties.OnReservationCompleted(beacon, user);
				if (reservations != null)
				{
					reservations.RemoveAll((ReservationNotificationCallback_t p) => p.m_ulBeaconID == beacon && p.m_steamIDJoiner == user);
				}
			}

			public static bool OnReservationCompleted(UserData user)
			{
				if (reservations.Any((ReservationNotificationCallback_t p) => p.m_steamIDJoiner == user))
				{
					OnReservationCompleted(reservations.FirstOrDefault((ReservationNotificationCallback_t p) => p.m_steamIDJoiner == user).m_ulBeaconID, user);
					return true;
				}
				return false;
			}

			public static void ChangeNumOpenSlots(PartyBeaconID_t beacon, uint openSlots, Action<ChangeNumOpenSlotsCallback_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_ChangeNumOpenSlotsCallback_t == null)
					{
						m_ChangeNumOpenSlotsCallback_t = CallResult<ChangeNumOpenSlotsCallback_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamParties.ChangeNumOpenSlots(beacon, openSlots);
					m_ChangeNumOpenSlotsCallback_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool DestroyBeacon(PartyBeaconID_t beacon)
			{
				if (createdBeacons != null)
				{
					createdBeacons.RemoveAll((PartyBeaconID_t p) => p == beacon);
				}
				return SteamParties.DestroyBeacon(beacon);
			}

			public static PartyBeaconID_t[] GetBeacons()
			{
				uint numActiveBeacons = SteamParties.GetNumActiveBeacons();
				PartyBeaconID_t[] array = new PartyBeaconID_t[numActiveBeacons];
				for (uint num = 0u; num < numActiveBeacons; num++)
				{
					array[num] = SteamParties.GetBeaconByIndex(num);
				}
				return array;
			}

			public static PartyBeaconDetails? GetBeaconDetails(PartyBeaconID_t beacon)
			{
				if (SteamParties.GetBeaconDetails(beacon, out var pSteamIDBeaconOwner, out var pLocation, out var pchMetadata, 8193))
				{
					return new PartyBeaconDetails
					{
						id = beacon,
						owner = pSteamIDBeaconOwner,
						location = pLocation,
						metadata = pchMetadata
					};
				}
				return null;
			}

			public static void JoinParty(PartyBeaconID_t beacon, Action<JoinPartyCallback_t, bool> callback)
			{
				if (callback != null)
				{
					if (m_JoinPartyCallback_t == null)
					{
						m_JoinPartyCallback_t = CallResult<JoinPartyCallback_t>.Create();
					}
					SteamAPICall_t hAPICall = SteamParties.JoinParty(beacon);
					m_JoinPartyCallback_t.Set(hAPICall, callback.Invoke);
				}
			}

			public static bool GetBeaconLocationData(SteamPartyBeaconLocation_t location, ESteamPartyBeaconLocationData data, out string result)
			{
				return SteamParties.GetBeaconLocationData(location, data, out result, 8193);
			}

			private static void ReservationCallback(ReservationNotificationCallback_t arg)
			{
				if (reservations == null)
				{
					reservations = new List<ReservationNotificationCallback_t>();
				}
				reservations.Add(arg);
				eventReservationNotificationCallback.Invoke(arg);
			}
		}
	}
}
