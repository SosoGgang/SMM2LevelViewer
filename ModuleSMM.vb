Module ModuleSMM
    Public Const UR As String = "198174193181024108188204033027038009110065067055059092053071110013197170026126044073185151163192252147231138210253130239234135026040040007108000240149029107071034164200170245039067011106201189022119240223"
    Public MapWidth(1), MapHeight(1) As Integer
    Public Structure LvlHeader
        Dim StartY As Byte
        Dim GoalY As Byte
        Dim GoalX As Int16
        Dim Timer As Int16
        Dim ClearCA As Int16
        Dim DateYY As Int16
        Dim DateMM As Byte
        Dim DateDD As Byte
        Dim DateH As Byte
        Dim DateM As Byte
        Dim AutoscrollSpd As Byte
        Dim ClearCC As Byte
        Dim ClearCRC As Integer
        Dim GameVer As Integer
        Dim MFlag As Integer
        Dim ClearAttempts As Integer
        Dim ClearTime As Integer
        Dim CreationID As Integer
        Dim UploadID As Long
        Dim ClearVer As Integer
        Dim GameStyle As Int16
        Dim Name As String
        Dim Desc As String
    End Structure
    '关卡文件头H200
    Public LH As LvlHeader
    Public Structure MapObject
        Dim X As Integer
        Dim Y As Integer
        Dim W As Byte
        Dim H As Byte
        Dim Flag As Integer
        Dim CFlag As Integer
        Dim Ex As Integer
        Dim ID As Int16
        Dim CID As Int16
        Dim LID As Int16
        Dim SID As Int16
        Dim LinkType As Byte
    End Structure
    Public Structure MapGround
        Dim X As Byte
        Dim Y As Byte
        Dim ID As Byte
        Dim BID As Byte
    End Structure
    Public Structure MapHeader
        Dim Theme As Byte
        Dim AutoscrollType As Byte
        Dim BorFlag As Byte
        Dim Ori As Byte
        Dim LiqEHeight As Byte
        Dim LiqMode As Byte
        Dim LiqSpd As Byte
        Dim LiqSHeight As Byte
        Dim BorR As Integer
        Dim BorT As Integer
        Dim BorL As Integer
        Dim BorB As Integer
        Dim Flag As Integer
        Dim ObjCount As Integer
        Dim SndCount As Integer
        Dim SnakeCount As Integer
        Dim ClearPipCount As Integer
        Dim CreeperCount As Integer
        Dim iBlkCount As Integer
        Dim TrackBlkCount As Integer
        Dim GroundCount As Integer
        Dim TrackCount As Integer
        Dim IceCount As Integer
    End Structure
    Public Structure MapTrack
        Dim UN As Short
        Dim Flag As Byte
        Dim X As Byte
        Dim Y As Byte
        Dim Type As Byte
        Dim LID As Short
        Dim K0 As Integer
        Dim K1 As Integer
        Dim F0 As Byte
        Dim F1 As Byte
        Dim F2 As Byte
    End Structure
    Public Structure MapClearPipe
        Dim Index As Byte
        Dim NodeCount As Byte
        Dim Node() As MapClearPipeNode
    End Structure
    Public Structure MapClearPipeNode
        Dim type As Byte
        Dim index As Byte
        Dim X As Byte
        Dim Y As Byte
        Dim W As Byte
        Dim H As Byte
        Dim Dir As Byte
    End Structure
    Public Structure MapSnakeBlock
        Dim index As Byte
        Dim NodeCount As Byte
        Dim Node() As MapSnakeBlockNode
    End Structure
    Public Structure MapSnakeBlockNode
        Dim index As Byte
        Dim Dir As Byte
    End Structure
    Public Structure MapMoveBlock
        Dim index As Byte
        Dim NodeCount As Short
        Dim Node() As MapMoveBlockNode
    End Structure
    Public Structure MapMoveBlockNode
        Dim p0 As Byte
        Dim p1 As Byte
        Dim p2 As Byte
    End Structure
    Public Structure MapCreeper
        Dim index As Byte
        Dim NodeCount As Short
        Dim Node() As Byte
    End Structure
    Public MapCPipe() As MapClearPipe
    Public MapSnk() As MapSnakeBlock, OSNK As Integer
    Public TrackNode(,), GroundNode(,) As Integer
    Public TrackYPt(15, 2) As Point
    Public MapMoveBlk(), MapTrackBlk() As MapMoveBlock
    Public MapCrp() As MapCreeper
    Public ObjLinkType() As Byte
    '地图文件头H48
    Public MH(1) As MapHeader, MapHdr As MapHeader
    Public MapObj() As MapObject
    Public MapGrd() As MapGround
    Public MapIce() As MapGround
    Public MapTrk() As MapTrack
    Public ObjEng() As String = {"굼바", "엉금엉금", "뻐끔플라워", "해머브로스", "벽돌블럭", "？블럭", "딱딱블럭", "땅", "동전",
    "파이프", "스프링", "리프트", "쿵쿵이", "킬러대포", "버섯지형", "폭탄병", "반벽지형", "다리", "P스위치", "POW",
    "버섯", "도넛블럭", "구름블럭", "음표블럭", "파이어바", "가시돌이", "깃대블럭", "깃대", "가시하잉바", "히든블럭",
    "김수한무", "김수한무구름", "매그넘킬러", "1UP버섯", "파이어플라워", "슈퍼스타", "해골리프트", "시작 벽돌", "시작 화살표",
    "마귀", "가시거북?", "유령", "쿠파 피에로", "가시 블럭", "거대버섯", "신발굼바", "와르르", "대포", "징오징오", "성의 다리",
    "뛰용뛰용", "폴찍폴찍", "꽃충이", "컨베이어벨트", "버너", "문", "뽀꾸뽀꾸", "블랙뻐끔", "뚜", "궤도", "버블",
    "멍멍이", "쿠파", "얼음블럭", "덩굴", "벌", "화살표", "일방통행", "그라인더", "Player", "10/30/50동전", "플랫폼",
    "엉금엉금카", "키노피오", "가봉/철구", "돌블럭", "회오리", "부웅부웅", "선인", "P블럭", "대시발판", "USA버섯", "통통동글", "가시기둥",
    "스네이크블럭", "움직이는 블럭", "짜자어", "급한 경사로", "완만한 경사로", "롤카메라?", "세이브깃발", "시소", "핑크코인",
    "투명토관", "경사 컨베이어벨트", "열쇠", "개미", "워프박스", "쿠파주니어", "온오프 스위치", "점선 블럭", "수면 표시",
    "쪼르뚜", "피시본", "태양/달", "집게크레인", "나무", "긴 뻐끔플라워", "깜빡블록", "효과음", "온오프 가시블럭",
    "메카쿠파", "나무 상자", "트램펄린", "가시복어", "키노피코", "슈퍼해머", "으쌰", "고드름", "！블럭", "레미", "모톤",
    "래리", "웬디", "이기", "로이", "루드윅", "대포 박스", "프로펠러박스", "흉내굼바", "흉내킬러", "POW모자", "온오프 트램펄린"}
    Public ObjEng3() As String = {"굼바", "엉금엉금", "뻐끔플라워", "해머브로스", "벽돌블럭", "？블럭", "딱딱블럭", "땅", "동전",
    "파이프", "스프링", "리프트", "쿵쿵이", "킬러대포", "버섯지형", "폭탄병", "반벽지형", "다리", "P스위치", "POW",
    "버섯", "도넛블럭", "구름블럭", "음표블럭", "파이어바", "가시돌이", "깃대블럭", "깃대", "가시하잉바", "히든블럭",
    "김수한무", "김수한무구름", "매그넘킬러", "1UP버섯", "파이어플라워", "슈퍼스타", "해골리프트", "시작 벽돌", "시작 화살표",
    "마귀", "가시거북?", "유령", "쿠파 피에로", "가시 블럭", "너구리마리오", "신발굼바", "와르르", "대포", "징오징오", "성의 다리",
    "뛰용뛰용", "폴찍폴찍", "꽃충이", "컨베이어벨트", "버너", "문", "뽀꾸뽀꾸", "블랙뻐끔", "뚜", "궤도", "버블",
    "멍멍이", "쿠파", "얼음블럭", "덩굴", "벌", "화살표", "일방통행", "그라인더", "Player", "10/30/50동전", "플랫폼",
    "엉금엉금카", "키노피오", "가봉/철구", "돌블럭", "회오리", "부웅부웅", "선인", "P블럭", "대시발판", "개구리마리오", "통통동글", "가시기둥",
    "스네이크블럭", "움직이는 블럭", "짜자어", "급한 경사로", "완만한 경사로", "롤카메라?", "세이브깃발", "시소", "핑크코인",
    "투명토관", "경사 컨베이어벨트", "열쇠", "개미", "워프박스", "쿠파주니어", "온오프 스위치", "점선 블럭", "수면 표시",
    "쪼르뚜", "피시본", "태양/달", "집게크레인", "나무", "긴 뻐끔플라워", "깜빡블록", "효과음", "온오프 가시블럭",
    "메카쿠파", "나무 상자", "트램펄린", "가시복어", "키노피코", "슈퍼해머", "으쌰", "고드름", "！블럭", "레미", "모톤",
    "래리", "웬디", "이기", "로이", "루드윅", "대포 박스", "프로펠러박스", "흉내굼바", "흉내킬러", "POW모자", "온오프 트램펄린"}
    Public ObjEngW() As String = {"감바", "엉금엉금", "뻐끔플라워", "해머브로스", "벽돌블럭", "？블럭", "딱딱블럭", "땅", "동전",
    "파이프", "스프링", "리프트", "쿵쿵이", "킬러대포", "버섯지형", "폭탄병", "반벽지형", "다리", "P스위치", "POW",
    "버섯", "도넛블럭", "구름블럭", "음표블럭", "파이어바", "가시돌이", "깃대블럭", "깃대", "가시하잉바", "히든블럭",
    "김수한무", "김수한무구름", "매그넘킬러", "1UP버섯", "파이어플라워", "슈퍼스타", "해골리프트", "시작 벽돌", "시작 화살표",
    "마귀", "가시거북?", "유령", "쿠파 피에로", "가시 블럭", "망토마리오", "요시", "와르르", "대포", "징오징오", "성의 다리",
    "뛰용뛰용", "폴찍폴찍", "꽃충이", "컨베이어벨트", "버너", "문", "뽀꾸뽀꾸", "블랙뻐끔", "뚜", "궤도", "버블",
    "멍멍이", "쿠파", "얼음블럭", "덩굴", "벌", "화살표", "일방통행", "그라인더", "Player", "10/30/50동전", "플랫폼",
    "엉금엉금카", "키노피오", "가봉/철구", "돌블럭", "회오리", "부웅부웅", "선인", "P블럭", "대시발판", "P풍선", "통통동글", "가시기둥",
    "스네이크블럭", "움직이는 블럭", "짜자어", "급한 경사로", "완만한 경사로", "롤카메라?", "세이브깃발", "시소", "핑크코인",
    "투명토관", "경사 컨베이어벨트", "열쇠", "개미", "워프박스", "쿠파주니어", "온오프 스위치", "점선 블럭", "수면 표시",
    "쪼르뚜", "피시본", "태양/달", "집게크레인", "나무", "긴 뻐끔플라워", "깜빡블록", "소리", "온오프 가시블럭",
    "메카쿠파", "나무 상자", "트램펄린", "가시복어", "키노피코", "슈퍼해머", "으쌰", "고드름", "！블럭", "레미", "모톤",
    "래리", "웬디", "이기", "로이", "루드윅", "대포 박스", "프로펠러박스", "흉내굼바", "흉내킬러", "POW모자", "온오프 트램펄린"}
    Public ObjEngU() As String = {"굼바", "엉금엉금", "뻐끔플라워", "해머브로스", "벽돌블럭", "？블럭", "딱딱블럭", "땅", "동전",
    "파이프", "스프링", "리프트", "쿵쿵이", "킬러대포", "버섯지형", "폭탄병", "반벽지형", "다리", "P스위치", "POW",
    "버섯", "도넛블럭", "구름블럭", "음표블럭", "파이어바", "가시돌이", "깃대블럭", "깃대", "가시하잉바", "히든블럭",
    "김수한무", "김수한무구름", "매그넘킬러", "1UP버섯", "파이어플라워", "슈퍼스타", "해골리프트", "시작 벽돌", "시작 화살표",
    "마귀", "가시거북?", "유령", "쿠파 피에로", "가시 블럭", "프로펠러버섯", "요시", "와르르", "대포", "징오징오", "성의 다리",
    "뛰용뛰용", "폴찍폴찍", "꽃충이", "컨베이어벨트", "버너", "문", "뽀꾸뽀꾸", "블랙뻐끔", "뚜", "궤도", "버블",
    "멍멍이", "쿠파", "얼음블럭", "덩굴", "벌", "화살표", "일방통행", "그라인더", "Player", "10/30/50동전", "플랫폼",
    "엉금엉금카", "키노피오", "가봉/철구", "돌블럭", "회오리", "부웅부웅", "선인", "P블럭", "대시발판", "도토리마리오", "통통동글", "가시기둥",
    "스네이크블럭", "움직이는 블럭", "짜자어", "급한 경사로", "완만한 경사로", "롤카메라?", "세이브깃발", "시소", "핑크코인",
    "투명토관", "경사 컨베이어벨트", "열쇠", "개미", "워프박스", "쿠파주니어", "온오프 스위치", "점선 블럭", "수면 표시",
    "쪼르뚜", "피시본", "태양/달", "집게크레인", "나무", "긴 뻐끔플라워", "깜빡블록", "소리", "온오프 가시블럭",
    "메카쿠파", "나무 상자", "트램펄린", "가시복어", "키노피코", "슈퍼해머", "으쌰", "고드름", "！블럭", "레미", "모톤",
    "래리", "웬디", "이기", "로이", "루드윅", "대포 박스", "프로펠러박스", "흉내굼바", "흉내킬러", "POW모자", "온오프 트램펄린"}
    Public ObjEngD() As String = {"굼바", "엉금엉금", "뻐끔플라워", "해머브로스", "벽돌블럭", "？블럭", "딱딱블럭", "땅", "동전",
    "파이프", "스프링", "리프트", "쿵쿵이", "킬러대포", "버섯지형", "폭탄병", "반벽지형", "다리", "P스위치", "POW",
    "버섯", "도넛블럭", "구름블럭", "음표블럭", "파이어바", "가시돌이", "깃대블럭", "깃대", "가시하잉바", "히든블럭",
    "김수한무", "김수한무구름", "매그넘킬러", "1UP버섯", "파이어플라워", "슈퍼스타", "해골리프트", "시작 벽돌", "시작 화살표",
    "마귀", "가시거북?", "유령", "쿠파 피에로", "가시 블럭", "슈퍼벨", "신발굼바", "와르르", "대포", "징오징오", "성의 다리",
    "뛰용뛰용", "폴찍폴찍", "꽃충이", "컨베이어벨트", "버너", "문", "뽀꾸뽀꾸", "검은 꽃", "뚜", "궤도", "버블",
    "멍멍이", "고양이쿠파", "얼음블럭", "덩굴", "딱끔", "화살표", "일방통행", "그라인더", "Player", "10/30/50동전", "플랫폼",
    "엉금엉금카", "키노피오", "가봉/철구", "돌블럭", "회오리", "부웅부웅", "선인", "P블럭", "대시블록", "부메랑플라워", "통통동글", "가시기둥",
    "스네이크블럭", "궤도블록", "짜자어", "급한 경사로", "완만한 경사로", "롤카메라?", "세이브깃발", "시소", "핑크코인",
    "투명토관", "경사 컨베이어벨트", "열쇠", "개미병", "워프박스", "쿠파주니어", "온오프 스위치", "점선 블럭", "수면 표시",
    "쪼르뚜", "피시본", "태양/달", "집게크레인", "나무", "쭉쭉뻐끔", "깜빡블록", "소리", "온오프 가시블럭",
    "메카쿠파", "나무 상자", "트램펄린", "불뚝복어", "키노피코", "슈퍼해머", "으쌰", "고드름", "！블럭", "레미", "모톤",
    "래리", "웬디", "이기", "로이", "루드윅", "발사대박스", "프로펠러박스", "흉내굼바", "흉내킬러", "빨강POW박스", "온오프 트램펄린"}
    Public PT As String
    Public TileLoc(150, 2) As Point
    Public PipeLoc(3, 7) As Point
    Public GrdLoc(256) As Point


    Public Badges() As String = {"", "금리본메달", "은리본메달", "동리본메달", "금메달", "은메달", "동메달"}
    Public BadgesType() As String = {"메이커 포인트", "어마챌(쉬움)", "어마챌(보통)", "어마챌(어려움)", "어마챌(슈익)", "배틀점수", "클리어한 코스수", "최초클리어한 코스수", "베스트 타임 코스수", "주간 메이커 포인트)"}
    Public Function GetItemName(n As Integer, v As Integer) As String
        Select Case v
            Case 12621
                GetItemName = ObjEng(n)
            Case 13133
                GetItemName = ObjEng3(n)
            Case 22349
                GetItemName = ObjEngW(n)
            Case 21847
                GetItemName = ObjEngU(n)
            Case 22323
                GetItemName = ObjEngD(n)
            Case Else
                GetItemName = "?"
        End Select
    End Function
    Public Sub LoadLvlData(P As String, IO As Boolean)
        Dim Offset As Integer
        Offset = IIf(IO, &H201, &H2E0E1)

        FileOpen(1, P, OpenMode.Binary)
        FileGet(1, LH.StartY, &H0 + 1)
        FileGet(1, LH.GoalY, &H1 + 1)
        FileGet(1, LH.GoalX, &H2 + 1)
        FileGet(1, LH.Timer, &H4 + 1)
        FileGet(1, LH.ClearCA, &H6 + 1)
        FileGet(1, LH.DateYY, &H8 + 1)
        FileGet(1, LH.DateMM, &HA + 1)
        FileGet(1, LH.DateDD, &HB + 1)
        FileGet(1, LH.DateH, &HC + 1)
        FileGet(1, LH.DateM, &HD + 1)

        FileGet(1, LH.AutoscrollSpd, &HE + 1)
        FileGet(1, LH.ClearCC, &HF + 1)
        FileGet(1, LH.ClearCRC, &H10 + 1)
        FileGet(1, LH.GameVer, &H14 + 1)
        FileGet(1, LH.MFlag, &H18 + 1)
        FileGet(1, LH.ClearAttempts, &H1C + 1)
        FileGet(1, LH.ClearTime, &H20 + 1)
        FileGet(1, LH.CreationID, &H24 + 1)
        FileGet(1, LH.UploadID, &H28 + 1)
        FileGet(1, LH.ClearVer, &H30 + 1)

        FileGet(1, LH.GameStyle, &HF1 + 1)

        'VER TEST
        'LH.GameStyle = 12621

        Dim i, j As Long, S As String, K As Int16
        S = ""
        For i = 1 To &H42 Step 2
            FileGet(1, K, &HF4 + i)
            If K = 0 Then Exit For
            S += ChrW(K)
        Next
        LH.Name = S

        S = ""
        For i = 1 To &HCA Step 2
            FileGet(1, K, &H136 + i)
            If K = 0 Then Exit For
            S += ChrW(K)
        Next
        LH.Desc = S

        Dim M As Long
        FileGet(1, MapHdr.Theme, Offset + &H0)
        FileGet(1, MapHdr.AutoscrollType, Offset + &H1)
        FileGet(1, MapHdr.BorFlag, Offset + &H2)
        FileGet(1, MapHdr.Ori, Offset + &H3)
        FileGet(1, MapHdr.LiqEHeight, Offset + &H4)
        FileGet(1, MapHdr.LiqMode, Offset + &H5)
        FileGet(1, MapHdr.LiqSpd, Offset + &H6)
        FileGet(1, MapHdr.LiqSHeight, Offset + &H7)

        FileGet(1, MapHdr.BorR, Offset + &H8)
        FileGet(1, MapHdr.BorT, Offset + &HC)
        FileGet(1, MapHdr.BorL, Offset + &H10)
        FileGet(1, MapHdr.BorB, Offset + &H14)

        FileGet(1, MapHdr.Flag, Offset + &H18)
        FileGet(1, MapHdr.ObjCount, Offset + &H1C)
        FileGet(1, MapHdr.SndCount, Offset + &H20)
        FileGet(1, MapHdr.SnakeCount, Offset + &H24)
        FileGet(1, MapHdr.ClearPipCount, Offset + &H28)
        FileGet(1, MapHdr.CreeperCount, Offset + &H2C)
        FileGet(1, MapHdr.iBlkCount, Offset + &H30)
        FileGet(1, MapHdr.TrackBlkCount, Offset + &H34)

        FileGet(1, MapHdr.GroundCount, Offset + &H3C)
        FileGet(1, MapHdr.TrackCount, Offset + &H40)
        FileGet(1, MapHdr.IceCount, Offset + &H44)

        If IO Then
            '    ReDim ObjLocData(1, 300, 300), ObjInfo(1, 300, 300)
            '    For i = 0 To 300
            '        For M = 0 To 300
            '            ObjLocData(0, i, M) = ""
            '            ObjLocData(1, i, M) = ""

            '        Next
            '    Next
            ObjLocData = New ObjStr(1, 300, 300) {}
        End If


        '单位0x48  0x14500 (0x20 * 2600)Object
        ReDim MapObj(MapHdr.ObjCount - 1), ObjLinkType(60000)
        For M = 0 To MapHdr.ObjCount - 1
            FileGet(1, MapObj(M).X, Offset + &H48 + &H0 + M * &H20)
            FileGet(1, MapObj(M).Y, Offset + &H48 + &H4 + M * &H20)
            FileGet(1, MapObj(M).W, Offset + &H48 + &HA + M * &H20)
            FileGet(1, MapObj(M).H, Offset + &H48 + &HB + M * &H20)
            FileGet(1, MapObj(M).Flag, Offset + &H48 + &HC + M * &H20)
            FileGet(1, MapObj(M).CFlag, Offset + &H48 + &H10 + M * &H20)
            FileGet(1, MapObj(M).Ex, Offset + &H48 + &H14 + M * &H20)
            FileGet(1, MapObj(M).ID, Offset + &H48 + &H18 + M * &H20)
            FileGet(1, MapObj(M).CID, Offset + &H48 + &H1A + M * &H20)
            FileGet(1, MapObj(M).LID, Offset + &H48 + &H1C + M * &H20)
            FileGet(1, MapObj(M).SID, Offset + &H48 + &H1E + M * &H20)
            MapObj(M).LinkType = 0
        Next

        '0x14584  0x4B0 (0x4 * 300)Sound Effect
        '蛇砖块0x149F8  0x12D4 (0x3C4 * 5)Snake Block
        ReDim MapSnk(MapHdr.SnakeCount - 1)
        For M = 0 To MapHdr.SnakeCount - 1
            FileGet(1, MapSnk(M).index, Offset + &H149F8 + &H0 + M * &H3C4)
            FileGet(1, MapSnk(M).NodeCount, Offset + &H149F8 + &H1 + M * &H3C4)
            ReDim MapSnk(M).Node(MapSnk(M).NodeCount - 1)
            For i = 0 To MapSnk(M).NodeCount - 1
                FileGet(1, MapSnk(M).Node(i).index, Offset + &H149F8 + &H0 + M * &H3C4 + i * &H8)
                FileGet(1, MapSnk(M).Node(i).Dir, Offset + &H149F8 + &H6 + M * &H3C4 + i * &H8)
            Next
        Next

        '透明管0x15CCC  0xE420 (0x124 * 200)Clear Pipe
        ReDim MapCPipe(MapHdr.ClearPipCount - 1)
        For M = 0 To MapHdr.ClearPipCount - 1
            FileGet(1, MapCPipe(M).Index, Offset + &H15CCC + &H0 + M * &H124)
            FileGet(1, MapCPipe(M).NodeCount, Offset + &H15CCC + &H1 + M * &H124)
            ReDim MapCPipe(M).Node(MapCPipe(M).NodeCount - 1)
            For i = 0 To MapCPipe(M).NodeCount - 1
                FileGet(1, MapCPipe(M).Node(i).type, Offset + &H15CCC + &H4 + M * &H124 + i * &H8)
                FileGet(1, MapCPipe(M).Node(i).index, Offset + &H15CCC + &H5 + M * &H124 + i * &H8)
                FileGet(1, MapCPipe(M).Node(i).X, Offset + &H15CCC + &H6 + M * &H124 + i * &H8)
                FileGet(1, MapCPipe(M).Node(i).Y, Offset + &H15CCC + &H7 + M * &H124 + i * &H8)
                FileGet(1, MapCPipe(M).Node(i).W, Offset + &H15CCC + &H8 + M * &H124 + i * &H8)
                FileGet(1, MapCPipe(M).Node(i).H, Offset + &H15CCC + &H9 + M * &H124 + i * &H8)
                FileGet(1, MapCPipe(M).Node(i).Dir, Offset + &H15CCC + &HB + M * &H124 + i * &H8)
            Next
        Next

        '0x240EC  0x348 (0x54 * 10)Piranha Creeper
        ReDim MapCrp(MapHdr.CreeperCount - 1)
        For M = 0 To MapHdr.CreeperCount - 1
            FileGet(1, MapCrp(M).index, Offset + &H240EC + &H1 + M * &H54)
            FileGet(1, MapCrp(M).NodeCount, Offset + &H240EC + &H2 + M * &H54)
            ReDim MapCrp(M).Node(MapCrp(M).NodeCount - 1)
            For i = 0 To MapCrp(M).NodeCount - 1
                FileGet(1, MapCrp(M).Node(i), Offset + &H240EC + &H4 + &H1 + M * &H54 + i * &H4)
            Next
        Next

        '0x24434  0x1B8 (0x2C * 10)! Block
        ReDim MapMoveBlk(MapHdr.iBlkCount - 1)
        For M = 0 To MapHdr.iBlkCount - 1
            FileGet(1, MapMoveBlk(M).index, Offset + &H24434 + &H1 + M * &H2C)
            FileGet(1, MapMoveBlk(M).NodeCount, Offset + &H24434 + &H2 + M * &H2C)
            ReDim MapMoveBlk(M).Node(MapMoveBlk(M).NodeCount - 1)
            For i = 0 To MapMoveBlk(M).NodeCount - 1
                FileGet(1, MapMoveBlk(M).Node(i).p0, Offset + &H24434 + &H4 + &H0 + M * &H2C + i * &H4)
                FileGet(1, MapMoveBlk(M).Node(i).p1, Offset + &H24434 + &H4 + &H1 + M * &H2C + i * &H4)
                FileGet(1, MapMoveBlk(M).Node(i).p2, Offset + &H24434 + &H4 + &H2 + M * &H2C + i * &H4)
            Next
        Next

        '0x245EC  0x1B8 (0x2C * 10)Track Block
        ReDim MapTrackBlk(MapHdr.TrackBlkCount - 1)
        For M = 0 To MapHdr.TrackBlkCount - 1
            FileGet(1, MapTrackBlk(M).index, Offset + &H245EC + &H1 + M * &H2C)
            FileGet(1, MapTrackBlk(M).NodeCount, Offset + &H245EC + &H2 + M * &H2C)
            ReDim MapTrackBlk(M).Node(MapTrackBlk(M).NodeCount - 1)
            For i = 0 To MapTrackBlk(M).NodeCount - 1
                FileGet(1, MapTrackBlk(M).Node(i).p0, Offset + &H245EC + &H4 + &H0 + M * &H2C + i * &H4)
                FileGet(1, MapTrackBlk(M).Node(i).p1, Offset + &H245EC + &H4 + &H1 + M * &H2C + i * &H4)
                FileGet(1, MapTrackBlk(M).Node(i).p2, Offset + &H245EC + &H4 + &H2 + M * &H2C + i * &H4)
            Next
        Next

        '地面0x247A4  0x3E80 (0x4 * 4000)Ground
        ReDim MapGrd(MapHdr.GroundCount - 1)
        ReDim GroundNode(300, 300)
        For M = 0 To 300
            For j = 0 To 300
                GroundNode(M, j) = 0
            Next
        Next
        For M = 0 To MapHdr.GroundCount - 1
            FileGet(1, MapGrd(M).X, Offset + &H247A4 + &H0 + M * &H4)
            FileGet(1, MapGrd(M).Y, Offset + &H247A4 + &H1 + M * &H4)
            FileGet(1, MapGrd(M).ID, Offset + &H247A4 + &H2 + M * &H4)
            FileGet(1, MapGrd(M).BID, Offset + &H247A4 + &H3 + M * &H4)
            GroundNode(MapGrd(M).X + 1, MapGrd(M).Y + 1) = 1
        Next
        If IO Then
            For j = (LH.GoalX - 5) / 10 To (LH.GoalX - 5) / 10 + 9
                For i = 0 To LH.GoalY - 1
                    GroundNode(j + 1, i + 1) = 1
                Next
            Next
            For j = 0 To 6
                For i = 0 To LH.StartY - 1
                    GroundNode(j + 1, i + 1) = 1
                Next
            Next
        End If
        '轨道0x28624  0x4650 (0xC * 1500)Track
        ReDim MapTrk(MapHdr.TrackCount - 1)
        ReDim TrackNode((MapHdr.BorR) + 3, (MapHdr.BorT) + 3)
        Dim TX As Byte
        For M = 0 To MapHdr.TrackCount - 1
            FileGet(1, MapTrk(M).UN, Offset + &H28624 + &H0 + M * &HC)
            FileGet(1, MapTrk(M).Flag, Offset + &H28624 + &H2 + M * &HC)
            FileGet(1, TX, Offset + &H28624 + &H3 + M * &HC)
            If TX = 255 Then
                MapTrk(M).X = 0
            Else
                MapTrk(M).X = TX + 1
            End If
            FileGet(1, TX, Offset + &H28624 + &H4 + M * &HC)
            If TX = 255 Then
                MapTrk(M).Y = 0
            Else
                MapTrk(M).Y = TX + 1
            End If
            FileGet(1, MapTrk(M).Type, Offset + &H28624 + &H5 + M * &HC)
            FileGet(1, MapTrk(M).LID, Offset + &H28624 + &H6 + M * &HC)
            FileGet(1, MapTrk(M).K0, Offset + &H28624 + &H8 + M * &HC)
            FileGet(1, MapTrk(M).K1, Offset + &H28624 + &HA + M * &HC)
            'MapTrk(M).K0 = MapTrk(M).K0 >> 16
            'MapTrk(M).K1 = MapTrk(M).K1 >> 16
            Select Case MapTrk(M).Type
                Case 0
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 1) += 1
                    TrackNode(MapTrk(M).X + 2, MapTrk(M).Y + 1) += 1
                    MapTrk(M).F0 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 7) Mod 2
                Case 1
                    TrackNode(MapTrk(M).X + 1, MapTrk(M).Y + 2) += 1
                    TrackNode(MapTrk(M).X + 1, MapTrk(M).Y) += 1
                    MapTrk(M).F0 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 7) Mod 2
                Case 2, 4, 5
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 2) += 1
                    TrackNode(MapTrk(M).X + 2, MapTrk(M).Y) += 1
                    MapTrk(M).F0 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 7) Mod 2
                Case 3, 6, 7
                    TrackNode(MapTrk(M).X + 2, MapTrk(M).Y + 2) += 1
                    TrackNode(MapTrk(M).X, MapTrk(M).Y) += 1
                    MapTrk(M).F0 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 7) Mod 2
                Case 8
                    'F0标记
                    MapTrk(M).F0 = (MapTrk(M).K1 >> 6) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F2 = ((MapTrk(M).K0 >> 15) + 1) Mod 2
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 2) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y + 4) += 1
                Case 9
                    MapTrk(M).F0 = (MapTrk(M).K1 >> 6) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 1) Mod 2
                    MapTrk(M).F2 = (MapTrk(M).K0 >> 7) Mod 2
                    TrackNode(MapTrk(M).X, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 4) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y + 2) += 1
                Case 10
                    MapTrk(M).F0 = ((MapTrk(M).K0 >> 14) + 1) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 6) Mod 2
                    MapTrk(M).F2 = (MapTrk(M).K0 >> 7) Mod 2
                    TrackNode(MapTrk(M).X, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X + 2, MapTrk(M).Y + 4) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y) += 1
                Case 11
                    MapTrk(M).F0 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 1) Mod 2
                    MapTrk(M).F2 = (MapTrk(M).K1 >> 6) Mod 2
                    TrackNode(MapTrk(M).X + 2, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 4) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y + 4) += 1
                Case 12
                    MapTrk(M).F0 = (MapTrk(M).K1 >> 11) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F2 = (MapTrk(M).K0 >> 12) Mod 2
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 2) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y + 4) += 1
                Case 13
                    MapTrk(M).F0 = (MapTrk(M).K1 >> 11) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K0 >> 12) Mod 2
                    MapTrk(M).F2 = (MapTrk(M).K0 >> 7) Mod 2
                    TrackNode(MapTrk(M).X, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 4) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y + 2) += 1
                Case 14
                    MapTrk(M).F0 = (MapTrk(M).K0 >> 12) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K1 >> 11) Mod 2
                    MapTrk(M).F2 = (MapTrk(M).K0 >> 7) Mod 2
                    TrackNode(MapTrk(M).X, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X + 2, MapTrk(M).Y + 4) += 1
                Case 15
                    MapTrk(M).F0 = (MapTrk(M).K0 >> 7) Mod 2
                    MapTrk(M).F1 = (MapTrk(M).K0 >> 12) Mod 2
                    MapTrk(M).F2 = (MapTrk(M).K1 >> 11) Mod 2
                    TrackNode(MapTrk(M).X + 2, MapTrk(M).Y) += 1
                    TrackNode(MapTrk(M).X, MapTrk(M).Y + 4) += 1
                    TrackNode(MapTrk(M).X + 4, MapTrk(M).Y + 4) += 1
            End Select
        Next
        '冰块0x2CC74  0x4B0 (0x4 * 300)Icicle
        ReDim MapIce(MapHdr.IceCount - 1)
        For M = 0 To MapHdr.IceCount - 1
            FileGet(1, MapIce(M).X, Offset + &H2CC74 + &H0 + M * &H4)
            FileGet(1, MapIce(M).Y, Offset + &H2CC74 + &H1 + M * &H4)
            FileGet(1, MapIce(M).ID, Offset + &H2CC74 + &H2 + M * &H4)
        Next


        FileClose(1)
    End Sub

    Public Structure ObjStr
        Dim Obj As String
        Dim Flag As String
        Dim State As String
        Dim SubObj As String
        Dim SubFlag As String
        Dim SubState As String
    End Structure
    Public ObjLocData(,,) As ObjStr
    Public Function GetItemImg(Obj As ObjStr, ByRef W As Integer, ByRef H As Integer) As Image
        Dim S0(), S1(), S2(), S3(), S4(), S5() As String
        If IsNothing(Obj.Obj) Then
            W = 0
            H = 0
            GetItemImg = Nothing
        Else
            S0 = Obj.Obj.Split(",")
            S1 = Obj.Flag.Split(",")
            S2 = Obj.State.Split(",")
            S3 = Obj.SubObj.Split(",")
            S4 = Obj.SubFlag.Split(",")
            S5 = Obj.SubState.Split(",")
            H = S0.GetUpperBound(0) * (64 + 6) - 6
            W = 64 * 2 + 32
            Dim BB As Bitmap = New Bitmap(W, H)
            Dim GG As Graphics = Graphics.FromImage(BB)
            'GG.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            Dim I, J As Integer
            For I = 0 To S0.GetUpperBound(0) - 1
                If S0(I).Length > 0 Then
                    GG.DrawImage(Image.FromFile(PT & "\IMG\" & LH.GameStyle.ToString & "\DLY\" & S0(I) & S2(I) & ".PNG"), 0, I * 70, 64, 64)
                    For J = 1 To S1(I).Length
                        GG.DrawImage(SetOpacity(Image.FromFile(PT & "\IMG\CMN\F0.PNG"), 1), J * 24 - 20, I * 70 + 70 - 32, 24, 24)
                        GG.DrawImage(SetOpacity(Image.FromFile(PT & "\IMG\" & LH.GameStyle.ToString & "\J" & Strings.Mid(S1(I), J, 1) & ".PNG"), 1), J * 24 - 20, I * 70 + 70 - 32, 24, 24)
                    Next
                    If S3(I).Length > 0 Then
                        GG.DrawImage(Image.FromFile(PT & "\IMG\CMN\G0.PNG"), 64, I * 70 + 16, 32, 32)
                        GG.DrawImage(Image.FromFile(PT & "\IMG\" & LH.GameStyle.ToString & "\DLY\" & S3(I) & S5(I) & ".PNG"), 88, I * 70, 64, 64)
                        For J = 1 To S4(I).Length
                            GG.DrawImage(SetOpacity(Image.FromFile(PT & "\IMG\CMN\F0.PNG"), 1), 88 - 20 + J * 24, I * 70 + 70 - 32, 24, 24)
                            GG.DrawImage(SetOpacity(Image.FromFile(PT & "\IMG\" & LH.GameStyle.ToString & "\J" & Strings.Mid(S4(I), J, 1) & ".PNG"), 1), 88 - 20 + J * 24, I * 70 + 70 - 32, 24, 24)

                        Next
                    End If
                End If
            Next
            GetItemImg = BB
            Form1.PicBot.Image = BB
        End If
    End Function

    Public Function SetOpacity(ByVal B As Bitmap, ByVal D As Double) As Bitmap
        Try
            Dim bmpDATA As New Imaging.BitmapData
            Dim tmpBMP = New Bitmap(B)
            Dim Rct As Rectangle = New Rectangle(0, 0, B.Width, B.Height)
            bmpDATA = tmpBMP.LockBits(Rct, Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format32bppArgb)
            Dim BTS(bmpDATA.Stride * bmpDATA.Height) As Byte
            Runtime.InteropServices.Marshal.Copy(bmpDATA.Scan0, BTS, 0, BTS.Length - 1)
            Dim T As Double = 0
            For I As Integer = 0 To BTS.Length - 4 Step 4
                T = BTS(I + 3)
                T = T * D
                BTS(I + 3) = T
            Next
            Runtime.InteropServices.Marshal.Copy(BTS, 0, bmpDATA.Scan0, BTS.Length - 1)
            tmpBMP.UnlockBits(bmpDATA)
            Return tmpBMP
        Catch
            Return Nothing
        End Try
    End Function
End Module
