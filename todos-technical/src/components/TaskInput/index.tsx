import styled from "@emotion/styled";
import { Button, Input } from "@mui/material";
import { useState } from "react";
import { TodoItem } from "../../types/TodoItem";
import { createTask } from "../../api/tasks";

interface TaskInputProps {
	setItems: React.Dispatch<React.SetStateAction<TodoItem[]>>;
}

export default function TaskInput({ setItems }: TaskInputProps) {
	const [value, setValue] = useState("");
	const [disabled, setDisabled] = useState(false);
	const addItem = async () => {
		setDisabled(true);
		const newItem: TodoItem = await createTask({ text: value });
		setDisabled(false);
		setValue("");
		setItems((prev) => [...prev, newItem]);
	};
	const handleChangeValue = (e: React.ChangeEvent<HTMLInputElement>) => {
		setValue(e.target.value);
	};

	return (
		<InputContainer>
			<Input value={value} onChange={handleChangeValue} />
			<Button onClick={addItem} disabled={disabled}>
				Add Task
			</Button>
		</InputContainer>
	);
}

const InputContainer = styled.div`
	width: 1000px;
	height: 40px;
	padding: 0 30px;
	display: flex;
	justify-content: space-between;
	align-items: center;
`;
