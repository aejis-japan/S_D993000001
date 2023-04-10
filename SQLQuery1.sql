--SELECT * FROM MTANTO WHERE MTanTantoID = '' AND MTanTanPass = ''  AND MTanTanNam

INSERT INTO DSYSLOG(
DSysPG_ID,DSysDate,DSysTim,DSysOpeID,DSysOpeNam,DSysOpeKbn,DSysTestKIbn,DSysOpeMsg) 
VALUES(
'S_D993000001',
FORMAT(GETDATE(),'yyyMMdd'),
FORMAT(GETDATE(),'HHmmss'),
'1111',
'徳山重人',
2,
1,
'Login successed')

select * from DSYSLOG

INSERT INTO DSYSLOG(
DSysPG_ID,DSysDate,DSysTim,DSysOpeID,DSysOpeNam,DSysOpeKbn,DSysTestKIbn,DSysOpeMsg) 
VALUES(
'S_D993000001',
FORMAT(GETDATE(),'yyyMMdd'),
FORMAT(GETDATE(),'HHmmss'),
'1111',
'徳山 重人',
2,
1,
'Login Successed')

delete from DSYSLOG

delete from DLIXIL

SELECT * FROM DLIXIL	

SELECT DLIXIL.DLixilBukenNo FROM DLIXIL	GROUP BY DLixilBukenNo

select * from MSHOHIN_CL order by Hinsort

select * from MCOMPANY	
SELECT * FROM MBRAND ORDER BY MBrBrCD

SELECT * FROM MBRAND ORDER BY MBrBrCD

INSERT 
INTO DLIXIL( 
[DLixilDLKbn]
, [DLixilHatyuNo]
, [DLixilTrainJIgyoCD]
, [DLixilTrainTokuCD]
, [DLixilBukenNo]
, [DLixilBiko]
, [DLixilSetNo]
, [DLixilKanseiGyoNo]
, [DLixilMeisaiGyoNo]
, [DLixilHinCD]
, [DLixilHinNam]
, [DLixilJodai]
, [DLixilTanka]
, [DLixilGenka]
, [DLixilHinNaibuCD]
, [DLixilHatyuSu]
, [DLixilHkiate1]
, [DLixilHkiate2]
, [DLixilHkiate3]
, [DLixilHkiate4]
, [DLixilHkiate5]
, [DLixilHkiate6]
, [DLixilSiteiNouhinDay]
, [DLixilAnswerDay1]
, [DLixilAnswerDay2]
, [DLixilAnswerDay3]
, [DLixilAnswerDay4]
, [DLixilAnswerDay5]
, [DLixilAnswerDay6]
, [DLxilAnswerKbn1]
, [DLxilAnswerKbn2]
, [DLxilAnswerKbn3]
, [DLxilAnswerKbn4]
, [DLxilAnswerKbn5]
, [DLxilAnswerKbn6]
, [DLxilCustomerCD]
, [DLxilCustomerTokuiCD]
, [DLxilGenbaNam]
, [DLxilHatyuDay]
, [DLixilLixilUkeDay]
, [DLixilSuKanriKbn]
, [DLixilHatyyuKeitaiKbn]
, [DLixilZaikoKbn]
, [DLixilBillitemKbn]
, [DLixilNini1]
, [DLixilNini2]
, [DLixilNini3]
, [DLixilNini4-1]
, [DLixilNini4-2]
, [DLixilNini4-3]
, [DLixilNini5]
, [DLixilNini6]
, [DLixilYobi1]
, [DLixilYobi2]
, [DLixilYobi3]
, [DLixilYobi4]
, [DLixilYobi5]
, [DLixilYobi6]
, [DLixilYobi7]
, [DLixilYobi8]
, [DLixilYobi9]
, [DLixilYobi10]
, [DLixilTyuNo]
, [DLixilSize2]
, [DLixilSize1]
, [DLixilTokutyuSiyoKbn1]
, [DLixilTokutyuSiyoNam1]
, [DLixilTokutyuSiyoSize1]
, [DLixilTokutyuSiyoKbn2]
, [DLixilTokutyuSiyoNam2]
, [DLixilTokutyuSiyoSize2]
, [DLixilTokutyuSiyoKbn3]
, [DLixilTokutyuSiyoNam3]
, [DLixilTokutyuSiyoSize3]
, [DLixilInputKbn]
, [DLixilToritukeNo]
, [DLixilToritukeNam]
, [DLixilDairiHatyuKanNo]
, [DLixilAutoNebikiCD]
, [DLixilShohinBunCD]
, [DLixilShoSyukeiCD]
, [DLixilUniqueCD]
, [DLixilUnderShopCD]
, [DLixilTostemNo]
, [DLixilTostemMituNo]
, [DLixilHaseiNo]
, [DLixilWindow]
, [DLixilSyuKbn]
, [DLixilLhinsyu]
, [DLixilLHinsyuKansan]
, [DLixilThinsyu]
, [DLixilTHinsyuKansan]
, [DLixilQhinsyu]
, [DLixilQHinsyuKansan]
, [DLixilEmpty]
, [DLixilInsDay]
, [DLixilInsTim]
, [DLixilInsID]
, [DLixilUpDay]
, [DLixilUpTim]
, [DLixilUpID]
, [DLixilCommitFlg]
) 
VALUES (
9201,'M202301010315','PSH9','607466',65906,'',1,6,1,'DD-0001-MAT1','ＬＫ引戸　召し合わせパッキン　引違４枚・引分２枚用　ＤＤ',2000,430
,430,'',1,1,0,0,0,0,0,'2023/1/30','2023/1/30','','','','','',1,0,0,0,0,0,'','','永田様邸　引戸採風タイプ','2023/1/17','2023/1/17'
,'',1,0,0,'','','','','','','','','','','','','','','','','','100','',0,0,'','',0,'','',0,'','',0,62,'2','','','X00900','1A0003','1R4502'
,'','','T010755317','M202301010315','10601','',0,'L90009','N','T40026','N','Q48796','Y','',FORMAT(GETDATE(), 'yyyMMdd')
,FORMAT(GETDATE(), 'HHmmss'),'1111',FORMAT(GETDATE(), 'yyyMMdd'),FORMAT(GETDATE(), 'HHmmss'),'1111',0)

SELECT * FROM DLIXIL

SELECT * FROM DLIXIL WHERE 
[DLixilHatyuNo] 			= 'M202301010315'
AND  [DLixilTrainJIgyoCD] 	= 'PSH9'
AND  [DLixilTrainTokuCD] 		= '607466'
AND  [DLixilBukenNo] 			= 65906
AND  [DLixilBiko] 			= ''
AND  [DLixilSetNo] 			= 1
AND  [DLixilKanseiGyoNo] 		= 6
AND  [DLixilMeisaiGyoNo] 		= 1
AND  [DLixilHinCD] 			= 'DD-0001-MAT1'
AND  [DLixilHinNam] 			= 'ＬＫ引戸　召し合わせパッキン　引違４枚・引分２枚用　ＤＤ'
AND  [DLixilJodai] 			= 2000
AND  [DLixilTanka] 			= 430
AND  [DLixilGenka] 			= 430
AND  [DLixilHinNaibuCD] 		= ''
AND  [DLixilHatyuSu] 			= 1
AND  [DLixilHkiate1] 			= 1
AND  [DLixilSiteiNouhinDay] 	=  '2023/1/30'
AND  [DLixilAnswerDay1] 		= '2023/1/30'
AND  [DLxilAnswerKbn1] 		=  1
AND  [DLxilAnswerKbn2] 		=  0
AND  [DLxilCustomerCD] 		=  ''
AND  [DLxilCustomerTokuiCD] 	=  ''
AND  [DLxilGenbaNam] 			= '永田様邸　引戸採風タイプ　'
AND  [DLxilHatyuDay] 			= '2023/1/17'
AND  [DLixilLixilUkeDay] 		= '2023/1/17'
AND  [DLixilSuKanriKbn] 		=  ''
AND  [DLixilHatyyuKeitaiKbn] 	= 1
AND  [DLixilZaikoKbn] 		= 0
AND  [DLixilBillitemKbn] 		= 0
AND  [DLixilNini1] 			= ''
AND  [DLixilTyuNo] 			=  ''
AND  [DLixilSize2] 			=  0
AND  [DLixilSize1] 			=  0
AND  [DLixilTokutyuSiyoKbn1] 	= ''
AND  [DLixilTokutyuSiyoNam1] 	= ''
AND  [DLixilTokutyuSiyoSize1] = 0
AND  [DLixilTokutyuSiyoKbn2] 	= ''
AND  [DLixilTokutyuSiyoNam2] 	= ''
AND  [DLixilTokutyuSiyoSize2] =0
AND  [DLixilTokutyuSiyoKbn3] 	= ''
AND  [DLixilTokutyuSiyoNam3] 	= ''
AND  [DLixilTokutyuSiyoSize3] =0
AND  [DLixilInputKbn] 		= 62
AND  [DLixilToritukeNo] 		= '2'
AND  [DLixilToritukeNam] 		= ''
AND  [DLixilDairiHatyuKanNo] 	= ''
AND  [DLixilAutoNebikiCD] 	= 'X00900'
AND  [DLixilShohinBunCD] 		= '1A0003'
AND  [DLixilShoSyukeiCD] 		= '1R4502'
AND  [DLixilUniqueCD] 		= ''
AND  [DLixilUnderShopCD] 		= ''
AND  [DLixilTostemNo] 		= 'T010755317'
AND  [DLixilTostemMituNo] 	= 'M202301010315'
AND  [DLixilHaseiNo] 			= '10601'
AND  [DLixilWindow] 			=  ''
AND  [DLixilSyuKbn] 			=  0
AND  [DLixilLhinsyu] 			= 'L90009'
AND  [DLixilLHinsyuKansan] 	= 'N'
AND  [DLixilThinsyu] 			= 'T40026'
AND  [DLixilTHinsyuKansan] 	= 'N'
AND  [DLixilQhinsyu] 			= 'Q48796'
AND  [DLixilQHinsyuKansan] 	= 'Y'


SELECT * FROM TLIXIL WHERE
TLixilBukenNo = 'T010755317'


DELETE DLIXIL

SELECT * FROM TLIXIL WHERE 
TLixilBukenNo = 'T010755317'


INSERT　INTO TLIXIL(
[TLixilBukenNo], [TLixilDLKbn], [TLixilNouAddress], [TLixilNouNam], [TLixilBrand], [TLixilBiko], 
[TLixilTantoID], [TLixilTanNam], [TLixilInsDay], [TLixilInsTim], [TLixilInsID], [TLixilUpDay], 
[TLixilUpTim], [TLixilUpID], [TLixilCommitFlg]
) 
VALUES(
'T010755317'
,0
,'未登録'
,'タマホーム'
,''
,'1111'
,'徳山 重人'
,FORMAT(GETDATE(),'yyyMMdd')
,FORMAT(GETDATE(),'HHmmss')
,'1111'
,FORMAT(GETDATE(),'yyyMMdd')
,FORMAT(GETDATE(),'HHmmss')
,'1111'
,0)

delete TLIXIL
delete DLIXIL
delete MBRAND


SELECT 
*
FROM TLIXIL
INNER JOIN DLIXIL ON TLIXIL.TLixilBukenNo = DLixilTostemNo

select * from DSYSLOG

select * from MBRAND

select * from DLIXIL

select * from TLIXIL

SELECT TLixilBukenNo,TLixilNouAddress,TLixilNouNam,TLixilTanNam,TLixilBrand,TLixilBrandCD 
FROM TLIXIL 
GROUP BY TLixilBukenNo, TLixilNouAddress,TLixilBrand,TLixilNouNam,TLixilTanNam,TLixilInsDay
ORDER BY TLixilInsDay

SELECT * FROM MCALENDER WHERE MCalDate = ''

SELECT TLixilBukenNo,TLixilNouAddress,TLixilNouNam,TLixilTanNam,TLixilBrand
FROM TLIXIL
WHERE TLixilBukenNo = 'T010705628'

SELECT * FROM MBRAND WHERE MBrParent <> 0 ORDER BY MBrBrKana

SELECT * FROM MBRAND WHERE MBrBrKana Like '%ｱ%' AND  MBrParent <> 0 ORDER BY MBrBrKana
SELECT * FROM MBRAND WHERE MBrBrKana Like '% ｱ%' AND MBrParent <> 0 ORDER BY MBrBrCD


UPDATE TLIXIL SET
 TLixilNouAddress = ''
,TLixilNouNam = ''
,TLixilBrandCD = 0
,TLixilBrand = ''
,TLixilTantoID = ''
,TLixilTanNam = ''
,TLixilUpDay = FORMAT(GETDATE(),'yyyMMdd')
,TLixilUpTim = FORMAT(GETDATE(),'HHmmss')
WHERE TLixilBukenNo = ''


SELECT TLixilPF FROM TLIXIL GROUP BY TLixilPF