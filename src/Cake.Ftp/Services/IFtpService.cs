﻿using System;
using System.Collections.Generic;
using Cake.Core.IO;
using FluentFTP;
using FluentFTP.Rules;

namespace Cake.Ftp.Services {
    /// <summary>
    /// Interface for the <see cref="FtpService"/> class. 
    /// </summary>
    public interface IFtpService {
        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="host">host of the FTP Client</param>
        /// <param name="remotePath">path on the file on the server</param>
        /// <param name="fileToUpload">The file to upload.</param>
        /// <param name="settings">Ftp Settings</param>
        void UploadFile(string host, string remotePath, IFile fileToUpload, FtpSettings settings);

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="host">host of the FTP Client</param>
        /// <param name="remotePath">path on the file on the server</param>
        /// <param name="settings">Ftp Settings</param>
        void DeleteFile(string host, string remotePath, FtpSettings settings);

        /// <summary>
        /// Creates a folder
        /// </summary>
        /// <param name="host">host of the FTP server</param>
        /// <param name="remotePath">path to create on the server</param>
        /// <param name="settings">The settings.</param>
        void CreateFolder(string host, string remotePath, FtpSettings settings);

        /// <summary>
        /// Upload and Overwite remote folder with local folder for default
        /// </summary>
        /// <param name="host"></param>
        /// <param name="remoteFolder"></param>
        /// <param name="localFolder"></param>
        /// <param name="settings"></param>
        /// <param name="ftpFolderSyncMode"></param>
        /// <param name="ftpRemoteExists"></param>
        /// <param name="ftpVerify"></param>
        /// <param name="rules"></param>
        /// <param name="process"></param>
        /// <returns></returns>
        List<FtpResult> UploadFolder(string host, string remoteFolder, string localFolder, FtpSettings settings,
            List<FtpRule> rules = null, Action<FtpProgress> process = null,
            FtpFolderSyncMode ftpFolderSyncMode = FtpFolderSyncMode.Mirror, FtpRemoteExists ftpRemoteExists = FtpRemoteExists.Overwrite, FtpVerify ftpVerify = FtpVerify.None
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="sourcePath"></param>
        /// <param name="remotePath"></param>
        /// <param name="settings"></param>
        /// <param name="parallel"></param>
        /// <param name="ignoreRule"></param>
        void UploadFolderParallel(string host, string remotePath, string sourcePath, FtpSettings settings, int parallel = 5, Func<string, bool> ignoreRule = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="remotePath"></param>
        /// <param name="settings"></param>
        void DeleteFolder(string host, string remotePath, FtpSettings settings);
        
        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="host"></param>
        /// <param name="remotePath"></param>
        /// <param name="localPath"></param>
        /// <param name="settings"></param>
        void DownloadFile(string host, string remotePath, string localPath, FtpSettings settings);
        
        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <param name="host">host of the FTP Client</param>
        /// <param name="directories">Dictionary keyed by the remote path with a list of local files to upload to the remote path</param>
        /// <param name="settings">Ftp Settings</param>
        void UploadDirectories(string host, Dictionary<string, IEnumerable<string>> directories, FtpSettings settings);
    }
}
