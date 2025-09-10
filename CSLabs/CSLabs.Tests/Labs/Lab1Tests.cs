using CSLabs.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLabs.Tests.Labs
{
    public class Lab1Tests
    {
        private readonly Lab1 _lab;
        private readonly string _sequencesText = "6.8 kDa mitochondrial proteolipid\tHomo sapiens (Human)\tMLQSIIKNIWIPMKPYYTKVYQEIWIGMGLMGFIVYKIRAADKRSKALKASAPAPGHH\r\nPre-T/NK cell associated protein 6H9A\tHomo sapiens (Human)\tMRLSCLVIITITAELCVPLMLCAHGEQAQLPRGVCVLGTGTSPAWSPVLLGRLPFPH\r\nAlcohol dehydrogenase\tBrachydanio rerio\tMDTTGKVIKCKAAVAWEAGKPLTIEEVEVAPPKAHEVRVKIHATGVCHTDAYTLSGSDPEGLFPVILGHEGAGTVESVGEGVTK\r\nRNA-dependent RNA polymerase [Fragment]\tSan Miguel sea lion virus\tPSGMPLTSIINSLNHCLMVGCAVVKALEDSGVQATWNIFDSMDLFTYGDDGVYIVPPLISSVMPKVFSNLRQFGLKPTRTDKTDAEITPIPADEPVEFLKRTIVRTENGIRALLDKSSII\r\nCecropin\tBombyx mori (Silk moth)\tRWKIFKKIEKVGQNIRDGIVKAGPAVAVVGQAATI";
        private readonly string _commandsText = "search\tSIIK\r\nsearch\tPLML\r\nsearch\tFK3I\r\ndiff\t6.8 kDa mitochondrial proteolipid\tAlcohol dehydrogenase\r\ndiff\tRNA-dependent RNA polymerase [Fragment]\tAlcohol dehydrogenase\r\ndiff\tCecropin\tPre-T/NK cell associated protein 6H9A\r\nmode\tCecropin\r\nmode\tAlcohol dehydrogenase";
        public Lab1Tests()
        {
            _lab = new Lab1(_sequencesText, _commandsText);
        }

    }
}
