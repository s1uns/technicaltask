const url = "https://localhost:7161/api/";
import axios from "axios";
import { GET_REQUEST, PUT_REQUEST, POST_REQUEST } from "../shared/constants";
axios.defaults.withCredentials = true;

export const createTask = async ({ text }: { text: string }) => {
	const response = await customRequest(
		POST_REQUEST,
		`${url}TaskItems/create-task`,
		{
			text: text,
		},
	);

	return response;
};

export const getTasks = async () => {
	const response = await customRequest(GET_REQUEST, `${url}TaskItems/items`);
	return response;
};

export const checkTask = async (id: string) => {
	const response = await customRequest(PUT_REQUEST, `${url}TaskItems/${id}`);
	return response;
};


// eslint-disable-next-line @typescript-eslint/no-explicit-any
const customRequest = async (method: string, url: string, data: any = null) => {
	try {
		const config = {
			method,
			url,
			data,
		};

		const response = await axios(config);
		return response.data;
		// eslint-disable-next-line @typescript-eslint/no-explicit-any
	} catch (err: any) {
		if (err.response) {
			return err.response.data;
		} else {
			return {
				success: false,
				message: "Couldn't send your request, retry later",
			};
		}
	}
};
