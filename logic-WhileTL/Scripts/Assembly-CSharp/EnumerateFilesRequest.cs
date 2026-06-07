using System.IO;
using Sony.PS4.SaveData;

public class EnumerateFilesRequest : FileOps.FileOperationRequest
{
	public override void DoFileOperations(Mounting.MountPoint mp, FileOps.FileOperationResponse response)
	{
		EnumerateFilesResponse obj = response as EnumerateFilesResponse;
		string data = mp.PathName.Data;
		obj.files = Directory.GetFiles(data, "*.txt", SearchOption.AllDirectories);
	}
}
