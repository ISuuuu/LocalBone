#ifndef _SP_ICCREADER_H
#define _SP_ICCREADER_H

#ifdef __cplusplus
extern "C" {
#endif

typedef struct tagICC_CONFIG {
	unsigned long port;
	unsigned long baud;
	unsigned long timeout;
	unsigned int PSAMSlot;
	unsigned int ICCSlot;
} ICC_CONFIG;

/*typedef struct tagICC_ACCOUNT{
unsigned int times;
unsigned long sums;
unsigned int number;
unsigned char keep1[128];
unsigned char keep2[128];
unsigned char keep3[128];
} ICC_ACCOUNT;*/

/*typedef struct tagICC_ACCOUNT
{
char times[(2*2)+1];	//�ۼƴ���,Cn��ʽ??
char sums[(9*2)+1];		//�ۼƽ��,Cn��ʽ??
char number[(8*2)+1];	//���κ�,An��ʽ
char keep1[(8*2)+1];	//Ԥ��1,AN��ʽ
char keep2[(9*2)+1];	//Ԥ��2,AN��ʽ
char keep3[(4*2)+1];	//Ԥ��3,AN��ʽ
}ICC_ACCOUNT;*/

typedef struct tagICC_ACCOUNT
{
char times[2];	//�ۼƴ���,Cn��ʽ??
char sums[9];	//�ۼƽ��,Cn��ʽ??
char number[8];	//���κ�,An��ʽ
char keep1[8];	//Ԥ��1,AN��ʽ
char keep2[9];	//Ԥ��2,AN��ʽ
char keep3[4];	//Ԥ��3,AN��ʽ
}ICC_ACCOUNT;
//˵��:���ṹ�淶��,�ü�¼ΪAN����(DF0A-EF0C-01)��



int __stdcall SP_ReaderInit(ICC_CONFIG *icc_Config);
int __stdcall SP_ReaderOpen(long *handle);
int __stdcall SP_ReaderStatus(long handle, unsigned char *status);
int __stdcall SP_PowerUpPSAM(long handle,char*ATR);
int __stdcall SP_PowerOffPSAM(long handle);
int __stdcall SP_PowerUpCPU(long handle,char *atr) ;
int __stdcall SP_PowerOffCPU(long handle);
int __stdcall SP_ReaderClose(long handle);
int __stdcall SP_GetReaderType(long handle, char *readerType);
int __stdcall SP_GetReaderSerial(long handle, char *readerSerial);
int __stdcall SP_GetLibVer(void);
 
int __stdcall SP_ReadSicardBasicInfo(long handle, char *cardNo, char *cardId);
//int __stdcall SP_ReadCPUcardBasicInfo(long handle,char * cardNo,char *cardSN);
int __stdcall SP_ReadIDInfo (long handle, char*IDNo);
int __stdcall SP_SendCommand(long handle, long commandLen, unsigned char *command_APDU, unsigned char *response_APDU,long *rlen);
int __stdcall SP_SendCommand_HEX(long handle, unsigned char *command_APDU, unsigned char *response_APDU);
int __stdcall SP_SendCommandPSAM(long handle, long commandLen, unsigned char * FAR command_APDU, unsigned char * FAR response_APDU,long *relen);
int __stdcall SP_SendCommandPSAM_HEX (long handle, unsigned char* FAR command_APDU, unsigned char* FAR response_APDU);
int __stdcall SP_SicardVerifyPIN(long handle, char *defaultPIN, int *retryTimes);
int __stdcall SP_SiCardResetPIN(long handle,char* defPIN);
int __stdcall SP_SicardChangePIN(long handle, char *defaultPIN, int *retryTimes,int keytype);
int __stdcall SP_SicardUnlock(long handle);


void __stdcall SP_GetErrMessage(int errNo, char *errMessage);
int __stdcall SP_ReaderKeyboardType(long handle, int* keyboardtype);

/*;;;;;;;;;;;2012/10/29����;;;;;;;;;;;;*/
int __stdcall SP_ReadAccountByHandle (long handle, ICC_ACCOUNT*  icc_Account);
int __stdcall SP_WriteAccountByHandle (long handle, ICC_ACCOUNT*  icc_Account);
int __stdcall SP_ReadSicardBasicInfos ( char*cardNo, char* cardId);
int __stdcall SP_ReadSicardBasicInfosPIN (char* PIN, char*cardNo, char* cardId);
int __stdcall SP_GetPSAMNo (char*psamNo);
int __stdcall SP_ReadAccount (ICC_ACCOUNT*  icc_Account);
int __stdcall SP_WriteAccount (ICC_ACCOUNT*  icc_Account);

int  __stdcall SP_SiReadCardInfo(long handle,char *PIN,int* retryTimes, char *cardInfos,char *errInfo);

//2013 QFX ADD
int __stdcall HB_ReaderStatus(char *status);
int __stdcall HB_ReaderCardID(char *cardid);
int __stdcall HB_ReaderCardNO(char *cardno);
int __stdcall HB_ReaderVtag(char *klx, char *kzt, char *zclx);
int __stdcall HB_WriteVtag(char *klx, char *kzt, char *zclx);
int __stdcall HB_ReaderPatientInfos(char *fkdq,
						  char *yljgdm, 
						  char *zjhm, 
						  char *zjlx, 
						  char *jg,
						  char *xm,
						  char *xb,
						  char *xx,
						  char *sjhm,
						  char *jzdz,
						  char *csrq,
						  char *mz);
int __stdcall HB_WritePatientInfos(char *fkdq,
						 char *yljgdm,
						 char *zjhm,
						 char *zjlx,
						 char *jg,
						 char *xm,
						 char *xb,
						 char *xx, 
						 char *sjhm, 
						 char *jzdz,  
						 char *csrq,
						 char *mz);


#ifdef __cplusplus
}
#endif


#endif // _SP_ICCREADER_H
