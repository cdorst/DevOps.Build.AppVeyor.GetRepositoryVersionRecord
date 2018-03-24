using DevOps.Build.AppVeyor.AzureStorageTableVersionLedger;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using static DevOps.Build.AppVeyor.GetAzureTable.AzureTableGetter;

namespace DevOps.Build.AppVeyor.GetRepositoryVersionRecord
{
    /// <summary>Function gets the given repository's version record from the Azure Storage Table AppVeyor build ledger</summary>
    public static class RepositoryVersionRecordGetter
    {
        /// <summary>Returns the given repository's build record from the Azure Storage Table AppVeyor build ledger</summary>
        public static async Task<RepositoryVersionTable> GetBuildRecordAsync(string name, string version)
        {
            var operation = TableOperation.Retrieve<RepositoryVersionTable>(name, version); var table = await GetTable(); var result = await table.ExecuteAsync(operation); if (result?.Result == null) return null; return (RepositoryVersionTable)result.Result;
        }
    }
}
