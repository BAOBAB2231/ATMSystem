# ATM 시스템

![image](https://github.com/user-attachments/assets/9ac7a3da-0266-41e4-9596-0ca275a42827)

Unity 기반으로 제작한 ATM 시뮬레이터입니다.

유저는 로그인 / 회원가입 후 입금, 출금, 송금 기능을 이용할 수 있습니다.

유저 데이터는 JSON 파일로 저장되어 프로그램 종료 후에도 유지됩니다.

---

## 주요 기능
- ### 회원가입 / 로그인

  - ID, Password, Name으로 회원가입 가능

  - ID로 로그인 시 UserData 자동 로드

- ### 입금 / 출금

  - 현금 → 계좌로 입금 가능

  - 계좌 → 현금으로 출금 가능

  - 금액 부족 시 에러 처리

- ### 송금 기능

  - 대상 ID 입력 → 계좌 간 송금 가능

  - 대상 ID 확인 → JSON 파일 기반으로 대상 확인 후 송금

  - 잔액 부족 및 대상 미존재 시 에러 처리

- ### 데이터 저장

  - UserData는 ID별 JSON 파일로 Assets/database 폴더에 저장됨

  - 로그인 시 자동 로드

---

## 사용 기술

- **Unity** 2022.3.17f1
- **C# (Visual Studio 사용)

---

# 사진 설명

## 시작화면
![image](https://github.com/user-attachments/assets/9ac7a3da-0266-41e4-9596-0ca275a42827)

로그인과 회원가입을 할 수 있습니다.

![image](https://github.com/user-attachments/assets/5fde818a-968d-4ed4-8f1c-3d4069579fa3)

아이디, 비밀번호를 입력하지 않거나 아이디가 존재하지 않고 비밀번호가 일치하지 않을 때 에러창이 뜹니다.

---

## 회원가입
![image](https://github.com/user-attachments/assets/db38f90b-893a-4941-9bdd-e867a7787e8d)

회원가입을 진행 할 수 있습니다.

![image](https://github.com/user-attachments/assets/0381e8e5-70bb-4579-b96b-8db3b77c5bd3)

입력을 제대로 하지 않거나, 비밀번호가 서로 일치하지 않고 이미 존재하는 계정이 있을 경우 에러창이 뜹니다.

---

## ATM
![image](https://github.com/user-attachments/assets/a5fbe392-b815-43a5-8c7a-e400930f98bf)

입금, 출금, 송금을 할 수 있습니다.

![image](https://github.com/user-attachments/assets/0468bf95-1d0a-4973-97db-92007ac04f5b)

잔액이 부족 할 경우 에러창이 뜹니다.

---
