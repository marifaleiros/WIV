using WIV.Data;
using System.Linq;
using WIV.Data.Repositories;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using System;

namespace WIV.Replication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var workItemRepo = new WorkItemRepository())
            {
                const string c_collectionUri = "https://fabrikam.visualstudio.com/DefaultCollection";
                const string c_projectName = "MyGreatProject";
                const string c_repoName = "MyRepo";

                // Interactively ask the user for credentials, caching them so the user isn't constantly prompted
                VssCredentials creds = new VssClientCredentials();
                creds.Storage = new VssClientCredentialStorage();

                // Connect to VSTS
                VssConnection connection = new VssConnection(new Uri(c_collectionUri), creds);

                // Get a GitHttpClient to talk to the Git endpoints
                GitHttpClient gitClient = connection.GetClient<GitHttpClient>();

                // Get data about a specific repository
                var repo = gitClient.GetRepositoryAsync(c_projectName, c_repoName).Result;

                var a = workItemRepo.GetAll().ToList();
            }
        }
    }
}
