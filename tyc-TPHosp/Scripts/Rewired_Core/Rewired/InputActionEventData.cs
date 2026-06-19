using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private dSBGNfhWmOBnJhxggXIGiXSpFLdE OBXrznbCnMzoPwqHmFDZHHQJihR;

		private InputActionEventType ITkGbXWlCKFKKxAWQFQzkQmJLNMz;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return ITkGbXWlCKFKKxAWQFQzkQmJLNMz;
			}
			internal set
			{
				ITkGbXWlCKFKKxAWQFQzkQmJLNMz = value;
			}
		}

		public Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(playerId);
			}
		}

		public string actionName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.bReSPxtAAhuMWEVILtQCAxJTMfu(actionId).name;
			}
		}

		public string actionDescriptiveName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return string.Empty;
				}
				return ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.bReSPxtAAhuMWEVILtQCAxJTMfu(actionId).descriptiveName;
			}
		}

		public float GetAxis()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.aKtyyQJXaksGFdepXiicilcqmAz();
		}

		public float GetAxisPrev()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.YuvFXJjoKbLzYOyrEHknhYlkvhl();
		}

		public float GetAxisDelta()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.cArkNyzMOorWWSNzObtLqCsVBtr();
		}

		public double GetAxisTimeActive()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.jBvTvekhPPSnTfOevseVOoANboiD();
		}

		public double GetAxisTimeInactive()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.lsDBpCjjvErUdqJrBXyEMtkgjQB();
		}

		public float GetAxisRaw()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.bvPTHnqrzMoGbcmasrUYlTzxMan();
		}

		public float GetAxisRawDelta()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.PEyjSkXKMLLKdhBrSUBseXpmtSe();
		}

		public float GetAxisRawPrev()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.aaRWGOqBZbRrpeNeRAkuZFnwpBQ();
		}

		public double GetAxisRawTimeActive()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.scNpoQFixNaoKeooFtxzugQJONOQ();
		}

		public double GetAxisRawTimeInactive()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.oFztjPFMuTUcIoFzBnKJwlnLemu();
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.goRWYwJTxXIwQvvlqTNFgLgQLGB();
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.OLHQNyfSZNjlIVgYtdCCJpVzLZI();
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.XvpCdaFqDlxJucqISdVdcRymbYxK();
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.gDpejzNTeeJRDkNPCyOtpfpYGmg();
		}

		public bool GetButton()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.tczGrLoSLQRKAWwrReBmbHatjKF();
		}

		public bool GetButtonPrev()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.hOuVCsfFccvyBzqOmUyNGejSnqg();
		}

		public bool GetButtonDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.wyMTjzWuSYHxxwaQSHqUbLUGgKg();
		}

		public bool GetButtonUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.KsQmhhakoIMsmFFssFWZgAtACAmj();
		}

		public bool GetButtonSinglePressHold()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.qGdIlqXDgmmfISyLXYdCpbxYquo();
		}

		public bool GetButtonSinglePressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.bLTbjPpppdHjbxMklgpfIqXRyYp();
		}

		public bool GetButtonSinglePressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.uTpONumFLTkWQBGLiuKkYLcPhqBe();
		}

		public bool GetButtonDoublePressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.QdNapEezgsjcIFSIbPqrnaMZYnq();
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.QdNapEezgsjcIFSIbPqrnaMZYnq(speed);
		}

		public bool GetButtonDoublePressHold()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.whhBjVbfHOZRjSSbvvVshFrslSsJ();
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.whhBjVbfHOZRjSSbvvVshFrslSsJ(speed);
		}

		public bool GetButtonDoublePressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.TtNcTNwxGEmdaqaGhItPkYvZUdO();
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.TtNcTNwxGEmdaqaGhItPkYvZUdO(speed);
		}

		public bool GetButtonTimedPress(float time)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.aDlFclJjaCPQLDrdiNxmhIBTyMI(time, 0f);
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.aDlFclJjaCPQLDrdiNxmhIBTyMI(time, expireIn);
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.sJWIGDsUFDoKbNAvyOYaskgwHl(time);
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.lCGBACeaSOuNLNMWNtxBERBspZZe(time, 0f);
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.lCGBACeaSOuNLNMWNtxBERBspZZe(time, expireIn);
		}

		public bool GetButtonShortPress()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.dKbahpClgHBuTgUPoelgHzAZVwQ();
		}

		public bool GetButtonShortPressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.axtYUltftYAAjLPpUwFjQcEktUM();
		}

		public bool GetButtonShortPressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.OeXCqNiCLCaJzCiThgBniwNKGycT();
		}

		public bool GetButtonLongPress()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.fgiCbahJbtQhKcuDieKIRhCuqUh();
		}

		public bool GetButtonLongPressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.iixuPYZWCGdNerQwVyFULoIHNjd();
		}

		public bool GetButtonLongPressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.gGlIKclBCWWWrDZXIZMThojjQoM();
		}

		public bool GetButtonRepeating()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.FmdAkBdCmGnmfuYHekqHitZeeAud();
		}

		public double GetButtonTimePressed()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.WauVOxzcNMHVLRuwItTTKDEMssd();
		}

		public double GetButtonTimeUnpressed()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.qspOkCVETJmjRdLTpzzGWWkmhaO();
		}

		public bool GetNegativeButton()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.KpRTXcEtyGlzHQYXMAstvlyskee();
		}

		public bool GetNegativeButtonPrev()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.VdfXOJuqKRFlPuSWWCQbwWJCAGE();
		}

		public bool GetNegativeButtonDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.KyvdceKirMVFNQGItYflXrFbvzb();
		}

		public bool GetNegativeButtonUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.ZwUMSLHJcuYAbRcebDaGJalfcRoE();
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.IVMAHIftfIRpuOqIAGjgiDkkRjin();
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.HbNlUNgsylguLzJPkeRobqoYHepA();
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.lwafttAKnLnDHJihTAGtqqzlIeee();
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.WyLjqxgprRvoNWgecDgFAQkYIrgd();
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.WyLjqxgprRvoNWgecDgFAQkYIrgd(speed);
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.OTglXCPZGItNKXZxLhhMYgiYbsV();
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.OTglXCPZGItNKXZxLhhMYgiYbsV(speed);
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.mjCeSzCOEPPLFcKnhpcBmZPiIPEW();
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.mjCeSzCOEPPLFcKnhpcBmZPiIPEW(speed);
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.tmlloKqIdCfFITAoOYARyaxEtyv(time, 0f);
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.tmlloKqIdCfFITAoOYARyaxEtyv(time, expireIn);
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.YtrbEJJmdYiNtYonULizSHGocQq(time);
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.LIllZNjOorYAJCuobbEpGHmtgLG(time, 0f);
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.LIllZNjOorYAJCuobbEpGHmtgLG(time, expireIn);
		}

		public bool GetNegativeButtonShortPress()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.TrIFGfGydgzIrCnTzSmtpMPcFRs();
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.wUSQKFPgCYLyOVIaLcaREOOgaSd();
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.rUpFbmIxUmCKBTXGxQRfuvWzAnM();
		}

		public bool GetNegativeButtonLongPress()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.ibyWTTbBqaiJKzbJQgrdCnhaOoU();
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.tQKWTalcnUHuIXUuxfVFuCyQaJWa();
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.zTPDXluCTGkSgLXaycbrprdTzeO();
		}

		public bool GetNegativeButtonRepeating()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.TTtEvsDAazCbegtEELzSwGKHTrig();
		}

		public double GetNegativeButtonTimePressed()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.vNaIOWRfUBghmmOJTErOPayDneE();
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return OBXrznbCnMzoPwqHmFDZHHQJihR.xLNJqBNrswsjyXJMOJMtKTJstvH();
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(playerId, actionId, true)?.GFxJnxIrzgBDMuFACVhmcASDNQU();
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(playerId, actionId, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controllerType) ?? false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(playerId, actionId, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controllerType, controllerId) ?? false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return ReInput.aPNcjJCKQolbdJEKHuJkfRPTMco.rOiHJUbkFlrKFFYgoEYHIeqSBPEh(playerId, actionId, true)?.elKCPWdvGzeJVgZCBKgGjZxHWHSK(controller) ?? false;
		}

		internal InputActionEventData(dSBGNfhWmOBnJhxggXIGiXSpFLdE vc, int playerId, int actionId, UpdateLoopType updateLoop)
		{
			ITkGbXWlCKFKKxAWQFQzkQmJLNMz = InputActionEventType.Update;
			OBXrznbCnMzoPwqHmFDZHHQJihR = vc;
			this.playerId = playerId;
			this.actionId = actionId;
			this.updateLoop = updateLoop;
		}
	}
}
